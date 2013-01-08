// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using Windows7.Location;
using Windows7.Sensors;

namespace SensorDiagnosticTool
{
    public partial class FormDiagTool : Form
    {
        /// <summary>
        /// Dictionary of custom SensorModel with SensorID as key
        /// </summary>
        private Dictionary<Guid, SensorModel> m_sensorDictionary;

        // LocationAPI
        private LatLongLocationProvider m_locationLatLong;
        private CivicAddressLocationProvider m_locationCivicAddress;

        // Constants
        private const uint MIN_REPORT_INTERVAL = 0;
        private const string NODE_SENSORS = "NodeSensors";
        private const string NODE_LOCATION = "NodeLocation";
        private const string NODE_LATLONG = "NodeLatLong";
        private const string NODE_CIVICADDRESS = "NodeCivicAddress";

        private ResourceManager m_resourceManager;

        public FormDiagTool()
        {
            InitializeComponent();

            m_resourceManager = new ResourceManager(GetType().FullName,
                                                    System.Reflection.Assembly.GetExecutingAssembly());

            m_locationLatLong = new LatLongLocationProvider(MIN_REPORT_INTERVAL);
            m_locationCivicAddress = new CivicAddressLocationProvider(MIN_REPORT_INTERVAL);
            SensorModel.Initialize(m_locationLatLong, m_locationCivicAddress, m_resourceManager);

            m_sensorDictionary = new Dictionary<Guid, SensorModel>();

            // Fill the UI
            TreeViewSensors_Initialize();
            TreeViewSensors_Populate();
            treeViewSensors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(TreeViewSensors_AfterSelect);

            SensorManager.SensorEnter += new SensorEnterEventHandler(SensorEnterHandler);
            m_locationLatLong.LocationChanged += new LocationChangedEventHandler(LocationChangedHandler);
            m_locationLatLong.StatusChanged +=
                new LocationProviderStatusChangedEventHandler(LocationStatusChangedHandler);
            m_locationCivicAddress.LocationChanged += new LocationChangedEventHandler(LocationChangedHandler);
            m_locationCivicAddress.StatusChanged +=
                new LocationProviderStatusChangedEventHandler(LocationStatusChangedHandler);

            // Log Location data at startup to have initial values
            SensorModel.LogReport((LocationReport) SensorModel.GetLatLongReport());
            SensorModel.LogReport((LocationReport) SensorModel.GetCivicAddressReport());
            SensorModel.LogReport(SensorModel.GetLatLongReportStatus());

            filter=new EventFilter<SendDataTextEventsArgs>(30);
            filter.FilteredEventRaised+=(sender, args) => PrintEventText(args.Data,args.Text);
        }

        /// <summary>
        /// Initializes treeViewSensors
        /// </summary>
        private void TreeViewSensors_Initialize()
        {
            // Add base nodes to tree
            TreeNode nodeSensors = new TreeNode(m_resourceManager.GetString("Sensors"));
            TreeNode nodeLatLong = new TreeNode(m_resourceManager.GetString("LatLong"));
            TreeNode nodeCivicAddress = new TreeNode(m_resourceManager.GetString("CivicAddress"));
            TreeNode nodeLocation = new TreeNode(m_resourceManager.GetString("Location"));
            nodeSensors.Name = NODE_SENSORS;
            nodeLatLong.Name = NODE_LATLONG;
            nodeCivicAddress.Name = NODE_CIVICADDRESS;
            nodeLocation.Name = NODE_LOCATION;
            nodeLocation.Nodes.Add(nodeLatLong);
            nodeLocation.Nodes.Add(nodeCivicAddress);
            treeViewSensors.Nodes.Add(nodeSensors);
            treeViewSensors.Nodes.Add(nodeLocation);
        }

        /// <summary>
        /// Populates treeViewSensors and m_sensorDictionary
        /// </summary>
        private void TreeViewSensors_Populate()
        {
            TreeNode nodeSensors = treeViewSensors.Nodes[NODE_SENSORS];
            TreeNode nodeLocation = treeViewSensors.Nodes[NODE_LOCATION];

            // Add any sensors to tree
            Sensor[] sensors = GetAllSensors();
            int sensorCount = sensors.Length;
            nodeSensors.Nodes.Clear();
            m_sensorDictionary.Clear();
            for (int i = 0; i < sensorCount; i++)
            {
                AddSensorToTree(sensors[i]);
            }

            // Expand tree
            nodeSensors.Expand();
            nodeLocation.Expand();
        }

        /// <summary>
        /// Helper function that wraps SensorManager.GetAllSensors()
        /// </summary>
        /// <returns>All sensors or Sensor[0] if no sensors.</returns>
        private Sensor[] GetAllSensors()
        {
            Sensor[] sensors = null;

            try
            {
                sensors = SensorManager.GetAllSensors();
            }
            catch (COMException ex)
            {
                switch (ex.ErrorCode)
                {
                    case SensorErrors.ERROR_NOT_FOUND:
                        sensors = new Sensor[0];
                        break;
                    default:
                        throw;
                }
            }

            return sensors;
        }

        /// <summary>
        /// Adds a sensor (new or returning) to treeViewSensors and connects events
        /// </summary>
        private void AddSensorToTree(Sensor sensor)
        {
            TreeNode nodeSensors = treeViewSensors.Nodes[NODE_SENSORS];

            sensor.DataUpdated += new SensorDataUpdatedEventHandler(DataUpdatedHandler);
            sensor.StateChanged += new SensorStateChangedEventHandler(StateChangedHandler);
            sensor.EventReceived += new SensorEventHandler(EventHandler);
            sensor.SensorLeave += new SensorLeaveEventHandler(LeaveHandler);

            TreeNode treeNodeSensor = new TreeNode(sensor.FriendlyName);
            treeNodeSensor.Name = sensor.SensorId.ToString();
            nodeSensors.Nodes.Add(treeNodeSensor);

            if (!m_sensorDictionary.ContainsKey(sensor.SensorId))
            {
                // Add sensor if this is first time seen
                m_sensorDictionary[sensor.SensorId] = new SensorModel(sensor);
            }
            else
            {
                // update sensor pointer if sensor is returning
                m_sensorDictionary[sensor.SensorId].Sensor = sensor;
            }

            try
            {
                m_sensorDictionary[sensor.SensorId].LogReport(sensor.State);
                m_sensorDictionary[sensor.SensorId].LogReport(sensor.GetDataReport());
            }
            catch (COMException ex)
            {
                switch (ex.ErrorCode)
                {
                    case SensorErrors.ERROR_NO_DATA:
                        // expected condition, continue
                        break;
                    default:
                        throw;
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 0x80070005 Access is denied. (E_ACCESSDENIED)
                // expected condition, continue
            }
        }

        private void TreeViewSensors_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs eventArgs)
        {
            RefreshGrids(eventArgs.Node);
        }

        /// <summary>
        /// Fills dataGrids for specific sensor node in treeViewSensors
        /// </summary>
        /// <param name="node">Node from trewView1 for sensor to be updated.</param>
        private void RefreshGrids(TreeNode node)
        {
            if (null != node)
            {
                Guid nodeSensorID;

                try
                {
                    nodeSensorID = new Guid(node.Name);
                }
                catch (FormatException)
                {
                    // If the format of node.Name is not correct for Guid construct, we want to use generic Guid
                    nodeSensorID = new Guid();
                }

                if (m_sensorDictionary.ContainsKey(nodeSensorID))
                {
                    // display specific Sensor info
                    m_sensorDictionary[nodeSensorID].FillGridsSensor(dataGridViewProperties, dataGridViewData);
                }
                else if (NODE_LATLONG == node.Name)
                {
                    // display latlong info
                    LatLongLocationReport latLongReport = SensorModel.GetLatLongReport();

                    dataGridViewProperties.Rows.Clear();
                    dataGridViewData.Rows.Clear();

                    if (null != latLongReport)
                    {
                        Guid sensorID = latLongReport.SensorID;
                        if (m_sensorDictionary.ContainsKey(sensorID))
                        {
                            m_sensorDictionary[sensorID].FillGridsSensor(dataGridViewProperties, dataGridViewData);
                        }
                    }

                    SensorModel.FillGridsLatLongReport(dataGridViewProperties, dataGridViewData);
                }
                else if (NODE_CIVICADDRESS == node.Name)
                {
                    // display CivicAddress info
                    SensorModel.FillGridsCivicAddressReport(dataGridViewProperties, dataGridViewData);
                }
            }
        }

        public void SensorEnterHandler(Sensor sensor, SensorState state)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SensorEnterHandler(sensor, state); }));
            }
            else
            {
                AddSensorToTree(sensor);

                // Log event
                Guid guidSensor = sensor.SensorId;
                DisplayEventString(String.Format(CultureInfo.CurrentUICulture,
                                                 m_resourceManager.GetString("EnterEventUI"),
                                                 m_sensorDictionary[guidSensor].FriendlyName));
                SensorModel.LogReport(String.Format(CultureInfo.InvariantCulture,
                                                    m_resourceManager.GetString("EnterEventXML"),
                                                    m_sensorDictionary[guidSensor].FriendlyName));
            }
        }

        public void StateChangedHandler(Sensor sensor, SensorState state)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { StateChangedHandler(sensor, state); }));
            }
            else
            {
                Guid guidSensor = sensor.SensorId;

                if (null != treeViewSensors.SelectedNode)
                {
                    // Refresh grids and show log if this sensor is selected
                    if (guidSensor.ToString() == treeViewSensors.SelectedNode.Name)
                    {
                        if (showEventsToolStripMenuItem.Checked)
                        {
                            RefreshGrids(treeViewSensors.SelectedNode);
                            DisplayEventString(String.Format(
                                CultureInfo.CurrentUICulture,
                                m_resourceManager.GetString("StateChangedEventUI"),
                                m_sensorDictionary[guidSensor].FriendlyName,
                                m_sensorDictionary[guidSensor].State));
                        }
                    }
                }

                // Log event
                if (m_sensorDictionary.ContainsKey(guidSensor))
                {
                    m_sensorDictionary[guidSensor].LogReport(state);
                }
            }
        }

        public void DataUpdatedHandler(Sensor sensor, SensorDataReport newData)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => DataUpdatedHandler(sensor, newData)));
            }
            else
            {
                Guid guidSensor = sensor.SensorId;

                if (null != treeViewSensors.SelectedNode)
                {
                    // Refresh grids and show log if this sensor is selected
                    if (guidSensor.ToString() == treeViewSensors.SelectedNode.Name)
                    {
                        if (showEventsToolStripMenuItem.Checked)
                        {
                            RefreshGrids(treeViewSensors.SelectedNode);
                            DisplayEventString(String.Format(
                                CultureInfo.CurrentUICulture,
                                m_resourceManager.GetString("DataUpdatedEventUI"),
                                m_sensorDictionary[guidSensor].FriendlyName));
                        }
                    }
                }

                // Log event
                if (m_sensorDictionary.ContainsKey(guidSensor))
                {
                    m_sensorDictionary[guidSensor].LogReport(newData);
                }
            }
        }

        public void EventHandler(Sensor sensor, Guid eventID, SensorDataReport newData)
        {
            // not used
        }

        public void LeaveHandler(Sensor sensor, Guid sensorID)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { LeaveHandler(sensor, sensorID); }));
            }
            else
            {
                TreeNode node = treeViewSensors.Nodes[NODE_SENSORS].Nodes[sensorID.ToString()];
                if (null != node)
                {
                    if (treeViewSensors.SelectedNode == node)
                    {
                        // set selected node to null, else a crash could happen via race condition
                        treeViewSensors.SelectedNode = null;
                    }
                    node.Remove(); // Update UI
                }

                if (m_sensorDictionary.ContainsKey(sensorID))
                {
                    SensorModel s = m_sensorDictionary[sensorID];
                    s.Sensor = null;

                    // Log event
                    DisplayEventString(String.Format(CultureInfo.CurrentUICulture,
                                                     m_resourceManager.GetString("LeaveEventUI"), s.FriendlyName));
                    SensorModel.LogReport(String.Format(CultureInfo.InvariantCulture,
                                                        m_resourceManager.GetString("LeaveEventXML"), s.FriendlyName));
                }

                // The SensorModel in sensorDictionary persists so the log information can be kept and written later
            }
        }

        public void LocationChangedHandler(LocationProvider locationProvider, LocationReport locationReport)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { LocationChangedHandler(locationProvider, locationReport); }));
            }
            else
            {
                if (null != treeViewSensors.SelectedNode)
                {
                    // Refresh grids and show log if this sensor is selected
                    if (NODE_LATLONG == treeViewSensors.SelectedNode.Name ||
                        NODE_CIVICADDRESS == treeViewSensors.SelectedNode.Name)
                    {
                        if (showEventsToolStripMenuItem.Checked)
                        {
                            RefreshGrids(treeViewSensors.SelectedNode);
                            DisplayEventString(String.Format(CultureInfo.CurrentUICulture,
                                                             m_resourceManager.GetString("LocationChangedEventUI")));
                        }
                    }
                }

                // Log event
                SensorModel.LogReport(locationReport);
            }
        }

        public void LocationStatusChangedHandler(LocationProvider locationProvider, ReportStatus newStatus)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { LocationStatusChangedHandler(locationProvider, newStatus); }));
            }
            else
            {
                if (null != treeViewSensors.SelectedNode)
                {
                    // Refresh grids and show log if this sensor is selected
                    if (NODE_LATLONG == treeViewSensors.SelectedNode.Name ||
                        NODE_CIVICADDRESS == treeViewSensors.SelectedNode.Name)
                    {
                        if (showEventsToolStripMenuItem.Checked)
                        {
                            RefreshGrids(treeViewSensors.SelectedNode);
                            DisplayEventString(String.Format(CultureInfo.CurrentUICulture,
                                                             m_resourceManager.GetString("LocationStatusChangedEventUI"),
                                                             SensorModel.GetReportStatus(newStatus)));
                        }
                    }
                }

                // Log event
                SensorModel.LogReport(newStatus);
            }
        }

        /// <summary>
        /// Add a log string to the UI
        /// </summary>
        /// <param name="str">String to be displayed.</param>
        private void DisplayEventString(string data)
        {
            string tempText = textBoxEvents.Text;
            var args = new SendDataTextEventsArgs(data, tempText);
            filter.HandleOriginalEvent(this, args);
        }

        private EventFilter<SendDataTextEventsArgs> filter;

        private void PrintEventText(string data, string tempText)
        {
            if (!showEventsToolStripMenuItem.Checked)
                return;
            data = String.Format(
                CultureInfo.CurrentUICulture,
                m_resourceManager.GetString("StringUI"),
                System.DateTime.Now.ToString(Constants.TIME_FORMAT, CultureInfo.CurrentUICulture.DateTimeFormat),
                data);
            data += Environment.NewLine;

            // Shorten stored text so fits within MaxLength of the text box
            while (tempText.Length + data.Length > textBoxEvents.MaxLength)
            {
                int newLineIndex = tempText.IndexOf(Environment.NewLine);
                if (newLineIndex > -1)
                {
                    tempText = tempText.Substring(newLineIndex + 1);
                }
                else
                {
                    // Could not find newline, overwrite all of the text box
                    tempText = "";
                    if (data.Length > textBoxEvents.MaxLength)
                    {
                        data = data.Substring(0, textBoxEvents.MaxLength);
                    }
                }
            }

            textBoxEvents.Text = tempText + data;

            // Scroll to bottom of textBox so newest event is viewable
            textBoxEvents.SelectionStart = textBoxEvents.TextLength;
            textBoxEvents.SelectionLength = 0;
            textBoxEvents.ScrollToCaret();
        }

        private void launchControlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string controlPath = Environment.ExpandEnvironmentVariables(@"%windir%\system32\control.exe");
            System.Diagnostics.Process.Start(controlPath, "/name Microsoft.LocationAndOtherSensors");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGrids(treeViewSensors.SelectedNode);
        }

        private void enableSensorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SensorManager.RequestPermission(this.Handle, false, GetAllSensors());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show dialog asking where to save log file
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.OverwritePrompt = true;

            dialog.FileName = String.Format(CultureInfo.InvariantCulture,
                                            m_resourceManager.GetString("SensorLogFileName"));
            dialog.DefaultExt = "xml";
            dialog.Filter =
                String.Format(CultureInfo.InvariantCulture, m_resourceManager.GetString("SensorLogFilterText")) +
                " (*.xml)|*.xml";

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                // Start writing log file
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.Create))
                {
                    XmlWriter writer = XmlWriter.Create(fs);
                    writer.WriteStartDocument();
                    writer.WriteStartElement(SensorXML.SENSOR_DIAGNOSTIC_TOOL);
                    writer.WriteAttributeString(SensorXML.VERSION, SensorXML.VERSION_NUMBER);

                    // Write log data for each sensor
                    foreach (KeyValuePair<Guid, SensorModel> kvp in m_sensorDictionary)
                    {
                        kvp.Value.WriteXML(writer);
                    }

                    // Write log for Location data
                    SensorModel.WriteXMLLocation(writer);

                    // End log file
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                    fs.Close();
                }
            }
        }
    }
}