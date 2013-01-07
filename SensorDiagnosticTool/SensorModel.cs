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
    class SensorModel
    {
        private Sensor m_sensor;

        /// <summary>
        /// Cached friendly name
        /// </summary>
        private string m_friendlyName;

        /// <summary>
        /// Data from the sensor
        /// </summary>
        private IDictionary<PropertyKey, object> m_dataDictionary;
        /// <summary>
        /// Properties from the sensor
        /// </summary>
        private IDictionary<PropertyKey, object> m_propertiesDictionary;

        // Logged data
        private IList<SensorDataReport> m_dataReports;
        private IList<string> m_stateReports;
        private static IList<string> s_enterReports;
        private static IList<LocationReport> s_locationReports;
        private static IList<string> s_locationStatusReports;

        // Location API helpers
        private static LatLongLocationProvider s_locationLatLong;
        private static CivicAddressLocationProvider s_locationCivicAddress;

        /// <summary>
        /// String names of Property Keys
        /// </summary>
        private static IDictionary<PropertyKey, string> s_keysNames;
        /// <summary>
        /// String names of Values from Property Keys
        /// </summary>
        private static IDictionary<PropertyKey, IDictionary<string, string>> s_keysValuesNames;

        private static ResourceManager s_resourceManager;

        private enum LatLongReportValue { Altitude, AltitudeError, ErrorRadius, Latitude, Longitude, Timestamp, SensorID };
        
        static SensorModel()
        {
            // Init dictionary to display property keys as strings
            s_keysNames = new Dictionary<PropertyKey, string>();
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ACCELERATION_X_G] = "SENSOR_DATA_TYPE_ACCELERATION_X_G";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ACCELERATION_Y_G] = "SENSOR_DATA_TYPE_ACCELERATION_Y_G";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ACCELERATION_Z_G] = "SENSOR_DATA_TYPE_ACCELERATION_Z_G";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ALTITUDE_ELLIPSOID_METERS] = "SENSOR_DATA_TYPE_ALTITUDE_ELLIPSOID_METERS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ALTITUDE_SEALEVEL_METERS] = "SENSOR_DATA_TYPE_ALTITUDE_SEALEVEL_METERS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ANGLE_X_DEGREES] = "SENSOR_DATA_TYPE_ANGLE_X_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ANGLE_Y_DEGREES] = "SENSOR_DATA_TYPE_ANGLE_Y_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ANGLE_Z_DEGREES] = "SENSOR_DATA_TYPE_ANGLE_Z_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_X_DEGREES_PER_SECOND] = "SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_X_DEGREES_PER_SECOND";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Y_DEGREES_PER_SECOND] = "SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Y_DEGREES_PER_SECOND";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Z_DEGREES_PER_SECOND] = "SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Z_DEGREES_PER_SECOND";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_BOOLEAN_SWITCH_ARRAY_STATE] = "SENSOR_DATA_TYPE_BOOLEAN_SWITCH_ARRAY_STATE";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_BOOLEAN_SWITCH_STATE] = "SENSOR_DATA_TYPE_BOOLEAN_SWITCH_STATE";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_DISTANCE_X_METERS] = "SENSOR_DATA_TYPE_DISTANCE_X_METERS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_DISTANCE_Y_METERS] = "SENSOR_DATA_TYPE_DISTANCE_Y_METERS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_DISTANCE_Z_METERS] = "SENSOR_DATA_TYPE_DISTANCE_Z_METERS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_ERROR_RADIUS_METERS] = "SENSOR_DATA_TYPE_ERROR_RADIUS_METERS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_FIX_QUALITY] = "SENSOR_DATA_TYPE_FIX_QUALITY";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_FIX_TYPE] = "SENSOR_DATA_TYPE_FIX_TYPE";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_FORCE_NEWTONS] = "SENSOR_DATA_TYPE_FORCE_NEWTONS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_HORIZONAL_DILUTION_OF_PRECISION] = "SENSOR_DATA_TYPE_HORIZONAL_DILUTION_OF_PRECISION";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_HUMAN_PRESENCE] = "SENSOR_DATA_TYPE_HUMAN_PRESENCE";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_HUMAN_PROXIMITY] = "SENSOR_DATA_TYPE_HUMAN_PROXIMITY";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_LATITUDE_DEGREES] = "SENSOR_DATA_TYPE_LATITUDE_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_LIGHT_LUX] = "SENSOR_DATA_TYPE_LIGHT_LUX";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_LONGITUDE_DEGREES] = "SENSOR_DATA_TYPE_LONGITUDE_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_MAGNETIC_HEADING_DEGREES] = "SENSOR_DATA_TYPE_MAGNETIC_HEADING_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_MAGNETIC_HEADING_X_DEGREES] = "SENSOR_DATA_TYPE_MAGNETIC_HEADING_X_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_MAGNETIC_HEADING_Y_DEGREES] = "SENSOR_DATA_TYPE_MAGNETIC_HEADING_Y_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_MAGNETIC_HEADING_Z_DEGREES] = "SENSOR_DATA_TYPE_MAGNETIC_HEADING_Z_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_MAGNETIC_VARIATION] = "SENSOR_DATA_TYPE_MAGNETIC_VARIATION";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_MULTIVALUE_SWITCH_STATE] = "SENSOR_DATA_TYPE_MULTIVALUE_SWITCH_STATE";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_POSITION_DILUTION_OF_PRECISION] = "SENSOR_DATA_TYPE_POSITION_DILUTION_OF_PRECISION";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_PRESSURE_PASCAL] = "SENSOR_DATA_TYPE_PRESSURE_PASCAL";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_RFID_TAG_40_BIT] = "SENSOR_DATA_TYPE_RFID_TAG_40_BIT";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SATELLITES_IN_VIEW] = "SENSOR_DATA_TYPE_SATELLITES_IN_VIEW";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_AZIMUTH] = "SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_AZIMUTH";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_ELEVATION] = "SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_ELEVATION";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_PRNS] = "SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_PRNS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_STN_RATIO] = "SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_STN_RATIO";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SATELLITES_USED_COUNT] = "SENSOR_DATA_TYPE_SATELLITES_USED_COUNT";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SATELLITES_USED_PRNS] = "SENSOR_DATA_TYPE_SATELLITES_USED_PRNS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_SPEED_KNOTS] = "SENSOR_DATA_TYPE_SPEED_KNOTS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_STRAIN] = "SENSOR_DATA_TYPE_STRAIN";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_TEMPERATURE_CELSIUS] = "SENSOR_DATA_TYPE_TEMPERATURE_CELSIUS";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_TIMESTAMP] = "SENSOR_DATA_TYPE_TIMESTAMP";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_TRUE_HEADING_DEGREES] = "SENSOR_DATA_TYPE_TRUE_HEADING_DEGREES";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_VERTICAL_DILUTION_OF_PRECISION] = "SENSOR_DATA_TYPE_VERTICAL_DILUTION_OF_PRECISION";
            s_keysNames[SensorPropertyKeys.SENSOR_DATA_TYPE_WEIGHT_KILOGRAMS] = "SENSOR_DATA_TYPE_WEIGHT_KILOGRAMS";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_ACCURACY] = "SENSOR_PROPERTY_ACCURACY";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_CHANGE_SENSITIVITY] = "SENSOR_PROPERTY_CHANGE_SENSITIVITY";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_CONNECTION_TYPE] = "SENSOR_PROPERTY_CONNECTION_TYPE";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_CURRENT_REPORT_INTERVAL] = "SENSOR_PROPERTY_CURRENT_REPORT_INTERVAL";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_DESCRIPTION] = "SENSOR_PROPERTY_DESCRIPTION";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_DEVICE_ID] = "SENSOR_PROPERTY_DEVICE_ID";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_FRIENDLY_NAME] = "SENSOR_PROPERTY_FRIENDLY_NAME";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_LIGHT_RESPONSE_CURVE] = "SENSOR_PROPERTY_LIGHT_RESPONSE_CURVE";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_MANUFACTURER] = "SENSOR_PROPERTY_MANUFACTURER";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_MIN_REPORT_INTERVAL] = "SENSOR_PROPERTY_MIN_REPORT_INTERVAL";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_MODEL] = "SENSOR_PROPERTY_MODEL";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_PERSISTENT_UNIQUE_ID] = "SENSOR_PROPERTY_PERSISTENT_UNIQUE_ID";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_RESOLUTION] = "SENSOR_PROPERTY_RESOLUTION";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_SAMPLING_RATE] = "SENSOR_PROPERTY_SAMPLING_RATE";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_SERIAL_NUMBER] = "SENSOR_PROPERTY_SERIAL_NUMBER";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_STATE] = "SENSOR_PROPERTY_STATE";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_TYPE] = "SENSOR_PROPERTY_TYPE";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_LOCATION_DESIRED_ACCURACY] = "SENSOR_PROPERTY_LOCATION_DESIRED_ACCURACY";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_RANGE_MINIMUM] = "SENSOR_PROPERTY_RANGE_MINIMUM";
            s_keysNames[SensorPropertyKeys.SENSOR_PROPERTY_RANGE_MAXIMUM] = "SENSOR_PROPERTY_RANGE_MAXIMUM";
            s_keysNames[WPDPropertyKeys.WPD_OBJECT_CAN_DELETE] = "WPD_OBJECT_CAN_DELETE";
            s_keysNames[WPDPropertyKeys.WPD_OBJECT_CONTENT_TYPE] = "WPD_OBJECT_CONTENT_TYPE";
            s_keysNames[WPDPropertyKeys.WPD_OBJECT_FORMAT] = "WPD_OBJECT_FORMAT";
            s_keysNames[WPDPropertyKeys.WPD_OBJECT_ID] = "WPD_OBJECT_ID";
            s_keysNames[WPDPropertyKeys.WPD_OBJECT_NAME] = "WPD_OBJECT_NAME";
            s_keysNames[WPDPropertyKeys.WPD_OBJECT_PARENT_ID] = "WPD_OBJECT_PARENT_ID";
            s_keysNames[WPDPropertyKeys.WPD_OBJECT_PERSISTENT_UNIQUE_ID] = "WPD_OBJECT_PERSISTENT_UNIQUE_ID";
            s_keysNames[WPDPropertyKeys.WPD_FUNCTIONAL_OBJECT_CATEGORY] = "WPD_FUNCTIONAL_OBJECT_CATEGORY";

            //KeysNames[SensorPropertyKeys.SENSOR_PROPERTY_COMMON_GUID] = "SENSOR_PROPERTY_COMMON_GUID";

            // Init dictionary to display property key values as strings
            s_keysValuesNames = new Dictionary<PropertyKey, IDictionary<string, string>>();

            // Value dictionary for Sensor Type
            Dictionary<string, string> dictionaryType = new Dictionary<string, string>();
            dictionaryType[SensorTypes.Accelerometer1d.ToString()] = "SENSOR_TYPE_ACCELEROMETER_1D";
            dictionaryType[SensorTypes.Accelerometer2d.ToString()] = "SENSOR_TYPE_ACCELEROMETER_2D";
            dictionaryType[SensorTypes.Accelerometer3d.ToString()] = "SENSOR_TYPE_ACCELEROMETER_3D";
            dictionaryType[SensorTypes.AmbientLight.ToString()] = "SENSOR_TYPE_AMBIENT_LIGHT";
            dictionaryType[SensorTypes.BarcodeScanner.ToString()] = "SENSOR_TYPE_BARCODE_SCANNER";
            dictionaryType[SensorTypes.BooleanSwitch.ToString()] = "SENSOR_TYPE_BOOLEAN_SWITCH";
            dictionaryType[SensorTypes.BooleanSwitchArray.ToString()] = "SENSOR_TYPE_BOOLEAN_SWITCH_ARRAY";
            dictionaryType[SensorTypes.Capacitance.ToString()] = "SENSOR_TYPE_CAPACITANCE";
            dictionaryType[SensorTypes.Compass1d.ToString()] = "SENSOR_TYPE_COMPASS_1D";
            dictionaryType[SensorTypes.Compass2d.ToString()] = "SENSOR_TYPE_COMPASS_2D";
            dictionaryType[SensorTypes.Compass3d.ToString()] = "SENSOR_TYPE_COMPASS_3D";
            dictionaryType[SensorTypes.Current.ToString()] = "SENSOR_TYPE_CURRENT";
            dictionaryType[SensorTypes.Distance1d.ToString()] = "SENSOR_TYPE_DISTANCE_1D";
            dictionaryType[SensorTypes.Distance2d.ToString()] = "SENSOR_TYPE_DISTANCE_2D";
            dictionaryType[SensorTypes.Distance3d.ToString()] = "SENSOR_TYPE_DISTANCE_3D";
            dictionaryType[SensorTypes.ElectricalPower.ToString()] = "SENSOR_TYPE_ELECTRICAL_POWER";
            dictionaryType[SensorTypes.EnvironmentalAtmosphericPressure.ToString()] = "SENSOR_TYPE_ENVIRONMENTAL_ATMOSPHERIC_PRESSURE";
            dictionaryType[SensorTypes.EnvironmentalHumidity.ToString()] = "SENSOR_TYPE_ENVIRONMENTAL_HUMIDITY";
            dictionaryType[SensorTypes.EnvironmentalTemperature.ToString()] = "SENSOR_TYPE_ENVIRONMENTAL_TEMPERATURE";
            dictionaryType[SensorTypes.EnvironmentalWindDirection.ToString()] = "SENSOR_TYPE_ENVIRONMENTAL_WIND_DIRECTION";
            dictionaryType[SensorTypes.EnvironmentalWindSpeed.ToString()] = "SENSOR_TYPE_ENVIRONMENTAL_WIND_SPEED";
            dictionaryType[SensorTypes.Force.ToString()] = "SENSOR_TYPE_FORCE";
            dictionaryType[SensorTypes.Gyrometer1d.ToString()] = "SENSOR_TYPE_GYROMETER_1D";
            dictionaryType[SensorTypes.Gyrometer2d.ToString()] = "SENSOR_TYPE_GYROMETER_2D";
            dictionaryType[SensorTypes.Gyrometer3d.ToString()] = "SENSOR_TYPE_GYROMETER_3D";
            dictionaryType[SensorTypes.HumanPresence.ToString()] = "SENSOR_TYPE_HUMAN_PRESENCE";
            dictionaryType[SensorTypes.HumanProximity.ToString()] = "SENSOR_TYPE_HUMAN_PROXIMITY";
            dictionaryType[SensorTypes.Inclinometer1d.ToString()] = "SENSOR_TYPE_INCLINOMETER_1D";
            dictionaryType[SensorTypes.Inclinometer2d.ToString()] = "SENSOR_TYPE_INCLINOMETER_2D";
            dictionaryType[SensorTypes.Inclinometer3d.ToString()] = "SENSOR_TYPE_INCLINOMETER_3D";
            dictionaryType[SensorTypes.Inductance.ToString()] = "SENSOR_TYPE_INDUCTANCE";
            dictionaryType[SensorTypes.LocationBroadcast.ToString()] = "SENSOR_TYPE_LOCATION_BROADCAST";
            dictionaryType[SensorTypes.LocationDeadReconing.ToString()] = "SENSOR_TYPE_LOCATION_DEAD_RECKONING";
            dictionaryType[SensorTypes.LocationGps.ToString()] = "SENSOR_TYPE_LOCATION_GPS";
            dictionaryType[SensorTypes.LocationLookup.ToString()] = "SENSOR_TYPE_LOCATION_LOOKUP";
            dictionaryType[SensorTypes.LocationOther.ToString()] = "SENSOR_TYPE_LOCATION_OTHER";
            dictionaryType[SensorTypes.LocationStatic.ToString()] = "SENSOR_TYPE_LOCATION_STATIC";
            dictionaryType[SensorTypes.LocationTriangulation.ToString()] = "SENSOR_TYPE_LOCATION_TRIANGULATION";
            dictionaryType[SensorTypes.MotionDetector.ToString()] = "SENSOR_TYPE_MOTION_DETECTOR";
            dictionaryType[SensorTypes.MultiValueSwitch.ToString()] = "SENSOR_TYPE_MULTIVALUE_SWITCH";
            dictionaryType[SensorTypes.Potentiometer.ToString()] = "SENSOR_TYPE_POTENTIOMETER";
            dictionaryType[SensorTypes.Pressure.ToString()] = "SENSOR_TYPE_PRESSURE";
            dictionaryType[SensorTypes.Resistance.ToString()] = "SENSOR_TYPE_RESISTANCE";
            dictionaryType[SensorTypes.RFIDScanner.ToString()] = "SENSOR_TYPE_RFID_SCANNER";
            dictionaryType[SensorTypes.Scale.ToString()] = "SENSOR_TYPE_SCALE";
            dictionaryType[SensorTypes.Speedometer.ToString()] = "SENSOR_TYPE_SPEEDOMETER";
            dictionaryType[SensorTypes.Strain.ToString()] = "SENSOR_TYPE_STRAIN";
            dictionaryType[SensorTypes.Touch.ToString()] = "SENSOR_TYPE_TOUCH";
            dictionaryType[SensorTypes.Voltage.ToString()] = "SENSOR_TYPE_VOLTAGE";
            s_keysValuesNames[SensorPropertyKeys.SENSOR_PROPERTY_TYPE] = dictionaryType;

            // Value dictionary for Sensor Category
            Dictionary<string, string> dictionaryCategory = new Dictionary<string, string>();
            dictionaryCategory[SensorCategories.All.ToString()] = "All";
            dictionaryCategory[SensorCategories.BioMetric.ToString()] = "BioMetric";
            dictionaryCategory[SensorCategories.Electrical.ToString()] = "Electrical";
            dictionaryCategory[SensorCategories.Environmental.ToString()] = "Environmental";
            dictionaryCategory[SensorCategories.Light.ToString()] = "Light";
            dictionaryCategory[SensorCategories.Location.ToString()] = "Location";
            dictionaryCategory[SensorCategories.Mechanical.ToString()] = "Mechanical";
            dictionaryCategory[SensorCategories.Motion.ToString()] = "Motion";
            dictionaryCategory[SensorCategories.Orientation.ToString()] = "Orientation";
            dictionaryCategory[SensorCategories.Scanner.ToString()] = "Scanner";
            s_keysValuesNames[WPDPropertyKeys.WPD_FUNCTIONAL_OBJECT_CATEGORY] = dictionaryCategory;

            // Init static logs
            s_enterReports = new List<string>();
            s_locationReports = new List<LocationReport>();
            s_locationStatusReports = new List<string>();
        }

        /// <summary>
        /// Initialize static members of SensorModel.
        /// </summary>
        public static void Initialize(LatLongLocationProvider latLongLocationProvider, CivicAddressLocationProvider civicAddressLocationProvider, ResourceManager resourceManager)
        {
            s_locationLatLong = latLongLocationProvider;
            s_locationCivicAddress = civicAddressLocationProvider;
            s_resourceManager = resourceManager;

            // Initialize more keys text because we have resourceManager now
            s_keysNames[SensorErrorValues.ERROR_NO_DATA] = String.Format(CultureInfo.CurrentUICulture, s_resourceManager.GetString("ErrorString"), s_resourceManager.GetString("NoData"));
            s_keysNames[SensorErrorValues.ERROR_ACCESS_DENIED] = String.Format(CultureInfo.CurrentUICulture, s_resourceManager.GetString("ErrorString"), s_resourceManager.GetString("AccessDenied"));

            // Value dictionary for Sensor State
            Dictionary<string, string> dictionaryState = new Dictionary<string, string>();
            dictionaryState[Convert.ToInt32(SensorState.AccessDenied).ToString()] = s_resourceManager.GetString("AccessDenied");
            dictionaryState[Convert.ToInt32(SensorState.Error).ToString()] = s_resourceManager.GetString("Error");
            dictionaryState[Convert.ToInt32(SensorState.Initializing).ToString()] = s_resourceManager.GetString("Initializing");
            dictionaryState[Convert.ToInt32(SensorState.NoData).ToString()] = s_resourceManager.GetString("NoData");
            dictionaryState[Convert.ToInt32(SensorState.NotAvailable).ToString()] = s_resourceManager.GetString("NotAvailable");
            dictionaryState[Convert.ToInt32(SensorState.Ready).ToString()] = s_resourceManager.GetString("Ready");
            s_keysValuesNames[SensorPropertyKeys.SENSOR_PROPERTY_STATE] = dictionaryState;
        }
        
        public SensorModel(Sensor sensor)
        {
            // Init log variables
            m_dataReports = new List<SensorDataReport>();
            m_stateReports = new List<string>();

            this.m_sensor = sensor;

            // Cache friendly name
            m_friendlyName = sensor.FriendlyName;

            m_dataDictionary = new Dictionary<PropertyKey,object>();
            m_propertiesDictionary = new Dictionary<PropertyKey,object>();

            // Update sensor info
            UpdateProperties();
            UpdateData();
        }

        /// <summary>
        /// Retrieves LatLongLocationReport from Location API
        /// </summary>
        /// <returns>Location Report or null.</returns>
        static public LatLongLocationReport GetLatLongReport()
        {
            LatLongLocationReport report = null;

            if (null != s_locationLatLong)
            {
                try
                {
                    report = (LatLongLocationReport)s_locationLatLong.GetReport();
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

            return report;
        }

        /// <summary>
        /// Retrieves ReportStatus from Location API
        /// </summary>
        /// <returns>Report Status or empty ReportStatus.</returns>
        static public ReportStatus GetLatLongReportStatus()
        {
            ReportStatus report = new ReportStatus();

            if (null != s_locationLatLong)
            {
                try
                {
                    report = s_locationLatLong.ReportStatus;
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

            return report;
        }

        /// <summary>
        /// Retrieves CivicAddressLocationReport from Location API
        /// </summary>
        /// <returns>Report or null.</returns>
        static public CivicAddressLocationReport GetCivicAddressReport()
        {
            CivicAddressLocationReport report = null;

            if (null != s_locationCivicAddress)
            {
                try
                {
                    report = (CivicAddressLocationReport)s_locationCivicAddress.GetReport();
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

            return report;
        }

        /// <summary>
        /// Returns the cached FriendlyName.
        /// </summary>
        public string FriendlyName
        {
            get
            {
                return m_friendlyName;
            }
        }

        /// <summary>
        /// The internal sensor.
        /// </summary>
        public Sensor Sensor
        {
            get
            {
                return m_sensor;
            }

            set
            {
                m_sensor = value;

                if (null != m_sensor)
                {
                    // done on a re-enter
                    // Cache friendly name
                    m_friendlyName = m_sensor.FriendlyName;

                    // Update sensor info
                    UpdateProperties();
                    UpdateData();
                }
            }
        }

        /// <summary>
        /// Returns the state of the sensor or empty string.
        /// </summary>
        public string State
        {
            get
            {
                string state = "";
                if (null != m_sensor)
                {
                    state = Enum.GetName(typeof(SensorState), m_sensor.State);
                }
                return state;
            }
        }

        /// <summary>
        /// Log a SensorDataReport.
        /// </summary>
        /// <param name="report">Report to be logged.</param>
        public void LogReport(SensorDataReport report)
        {
            m_dataReports.Add(report);
        }

        /// <summary>
        /// Log a custom string.
        /// </summary>
        /// <param name="report">Report to be logged.</param>
        public static void LogReport(string report)
        {
            report = String.Format(
                    CultureInfo.InvariantCulture,
                    s_resourceManager.GetString("StringXML"),
                    System.DateTime.Now.ToString(Constants.TIME_FORMAT, CultureInfo.InvariantCulture.DateTimeFormat),
                    report);
            s_enterReports.Add(report);
        }

        /// <summary>
        /// Log a SensorState.
        /// </summary>
        /// <param name="report">Report to be logged.</param>
        public void LogReport(SensorState state)
        {
            string report = String.Format(
                    CultureInfo.InvariantCulture,
                    s_resourceManager.GetString("StateChangedEventXML"),
                    System.DateTime.Now.ToString(Constants.TIME_FORMAT, CultureInfo.InvariantCulture.DateTimeFormat),
                    State);
            m_stateReports.Add(report);
        }

        /// <summary>
        /// Log a LocationReport.
        /// </summary>
        /// <param name="report">Report to be logged.</param>
        public static void LogReport(LocationReport report)
        {
            s_locationReports.Add(report);
        }

        /// <summary>
        /// Log a ReportStatus.
        /// </summary>
        /// <param name="report">Report to be logged.</param>
        public static void LogReport(ReportStatus report)
        {
            string reportString = String.Format(
                    CultureInfo.InvariantCulture,
                    s_resourceManager.GetString("LocationStatusChangedEventXML"),
                    System.DateTime.Now.ToString(Constants.TIME_FORMAT, CultureInfo.InvariantCulture.DateTimeFormat),
                    GetReportStatus(report));
            s_locationStatusReports.Add(reportString);
        }

        /// <summary>
        /// Fill grids with the most recent sensor properties and data
        /// </summary>
        /// <param name="gridViewProperties">Grid to be filled with properties.</param>
        /// <param name="gridViewData">Grid to be filled with data.</param>
        public void FillGridsSensor(DataGridView gridViewProperties, DataGridView gridViewData)
        {
            Update();
            FillEntries(gridViewProperties, m_propertiesDictionary);
            FillEntries(gridViewData, m_dataDictionary);
        }

        /// <summary>
        /// Fill grids with the most recent LatLong properties and data
        /// </summary>
        /// <param name="gridViewProperties">Grid to be filled with properties.</param>
        /// <param name="gridViewData">Grid to be filled with data.</param>
        public static void FillGridsLatLongReport(DataGridView gridViewProperties, DataGridView gridViewData)
        {
            try
            {
                LatLongLocationReport report = (LatLongLocationReport)s_locationLatLong.GetReport();

                gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("Altitude"), GetLatLongReportValue(report, LatLongReportValue.Altitude) });
                gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("AltitudeError"), GetLatLongReportValue(report, LatLongReportValue.AltitudeError) });
                gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("ErrorRadius"), GetLatLongReportValue(report, LatLongReportValue.ErrorRadius) });
                gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("Latitude"), GetLatLongReportValue(report, LatLongReportValue.Latitude) });
                gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("Longitude"), GetLatLongReportValue(report, LatLongReportValue.Longitude) });
                gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("Timestamp"), GetLatLongReportValue(report, LatLongReportValue.Timestamp) });

                string id = GetLatLongReportValue(report, LatLongReportValue.SensorID);

                if (SensorIDs.DEFAULT_LOCATION_PROVIDER == report.SensorID)
                {
                    gridViewProperties.Rows.Add(new string[] { s_resourceManager.GetString("SensorID"), s_resourceManager.GetString("DefaultLocationProvider") });
                }
                else
                {
                    gridViewProperties.Rows.Add(new string[] { s_resourceManager.GetString("SensorID"), id });
                }

                gridViewProperties.Rows.Add(new string[] { s_resourceManager.GetString("ReportStatus"), GetReportStatus(s_locationLatLong.ReportStatus) });
            }
            catch (COMException ex)
            {
                switch (ex.ErrorCode)
                {
                    case SensorErrors.ERROR_NO_DATA:
                        gridViewData.Rows.Add(new string[] { s_keysNames[SensorErrorValues.ERROR_NO_DATA], ex.Message });
                        break;
                    default:
                        throw;
                }
            }
        }

        /// <summary>
        /// Retrieves a string from a LatLongLocationReport for a specific LatLongReportValue case
        /// </summary>
        /// <param name="report">Report to get string from.</param>
        /// <param name="reportCase">Current case of report.</param>
        /// <returns>Name of report value or empty string.</returns>
        private static string GetLatLongReportValue(LatLongLocationReport report, LatLongReportValue reportCase)
        {
            string s = "";

            try
            {
                switch (reportCase)
                {
                    case LatLongReportValue.Altitude:
                        s = report.Altitude.ToString();
                        break;
                    case LatLongReportValue.AltitudeError:
                        s = report.AltitudeError.ToString();
                        break;
                    case LatLongReportValue.ErrorRadius:
                        s = report.ErrorRadius.ToString();
                        break;
                    case LatLongReportValue.Latitude:
                        s = report.Latitude.ToString();
                        break;
                    case LatLongReportValue.Longitude:
                        s = report.Longitude.ToString();
                        break;
                    case LatLongReportValue.SensorID:
                        s = report.SensorID.ToString();
                        break;
                    case LatLongReportValue.Timestamp:
                        s = report.Timestamp.ToString(Constants.TIME_FORMAT, CultureInfo.CurrentUICulture.DateTimeFormat);
                        break;
                }
            }
            catch (COMException ex)
            {
                switch (ex.ErrorCode)
                {
                    case SensorErrors.ERROR_NO_DATA:
                        // expected condition, continue
                        break;
                    case SensorErrors.TYPE_E_TYPEMISMATCH:
                        // expected condition, continue
                        break;
                    default:
                        throw;
                }
            }

            return s;
        }

        /// <summary>
        /// Fill grids with the most recent CivicAddress properties and data
        /// </summary>
        /// <param name="gridViewProperties">Grid to be filled with properties.</param>
        /// <param name="gridViewData">Grid to be filled with data.</param>
        public static void FillGridsCivicAddressReport(DataGridView gridViewProperties, DataGridView gridViewData)
        {
            CivicAddressLocationReport civicAddressReport = (CivicAddressLocationReport)s_locationCivicAddress.GetReport();

            gridViewProperties.Rows.Clear();
            gridViewData.Rows.Clear();

            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("Address1"), civicAddressReport.AddressLine1 });
            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("Address2"), civicAddressReport.AddressLine2 });
            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("City"), civicAddressReport.City });
            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("StateProvince"), civicAddressReport.StateOrProvince });
            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("ZipPostalCode"), civicAddressReport.PostalCode });
            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("CountryRegion"), civicAddressReport.CountryOrRegion });
            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("Timestamp"), civicAddressReport.Timestamp.ToString(Constants.TIME_FORMAT, CultureInfo.CurrentUICulture.DateTimeFormat) });
            gridViewData.Rows.Add(new string[] { s_resourceManager.GetString("DetailLevel"), civicAddressReport.DetailLevel.ToString() });

            if (SensorIDs.DEFAULT_LOCATION_PROVIDER == civicAddressReport.SensorID)
            {
                gridViewProperties.Rows.Add(new string[] { s_resourceManager.GetString("SensorID"), s_resourceManager.GetString("DefaultLocationProvider") });
            }
            else
            {
                gridViewProperties.Rows.Add(new string[] { s_resourceManager.GetString("SensorID"), civicAddressReport.SensorID.ToString() });
            }

            gridViewProperties.Rows.Add(new string[] { s_resourceManager.GetString("ReportStatus"), GetReportStatus(s_locationCivicAddress.ReportStatus) });
        }

        /// <summary>
        /// Retrieves a string representing the current ReportStatus
        /// </summary>
        /// <param name="status">ReportStatus to be converted to string.</param>
        /// <returns>Name of report status or empty string.</returns>
        public static string GetReportStatus(ReportStatus status)
        {
            return Enum.GetName(typeof(ReportStatus), status);
        }

        /// <summary>
        /// Fill a grid with values
        /// </summary>
        /// <param name="gridView">Grid to be filled.</param>
        /// <param name="entries">Dictionary of values.</param>
        private void FillEntries(DataGridView gridView, IDictionary<PropertyKey, object> entries)
        {
            gridView.Rows.Clear();

            if (entries.Count > 0)
            {
                foreach (KeyValuePair<PropertyKey, object> kvp in entries)
                {
                    gridView.Rows.Add(new string[] { GetKeyName(kvp.Key), GetKeyValueName(kvp.Key, kvp.Value) });
                }
            }
            else
            {
                gridView.Rows.Add(new string[] { s_resourceManager.GetString("NoEntries"), " " });
            }
        }

        /// <summary>
        /// Retrieve a string from KeysValuesNames
        /// </summary>
        /// <param name="key">Key in KeysValuesNames.</param>
        /// <param name="value">Key in KeysValuesNames' value's dictionary.</param>
        /// <returns>Returns string from KeysValuesNames or value.ToString()</returns>
        private static string GetKeyValueName(PropertyKey key, object value)
        {
            string name = "";

            if (null != value)
            {
                if (s_keysValuesNames.ContainsKey(key))
                {
                    IDictionary<string, string> tempValueNames = s_keysValuesNames[key];
                    if (tempValueNames.ContainsKey(value.ToString()))
                    {
                        name = tempValueNames[value.ToString()];
                    }
                    else
                    {
                        name = value.ToString();
                    }
                }
                else
                {
                    if (value is DateTime)
                    {
                        DateTime dt = (DateTime)value;
                        name = dt.ToString(Constants.TIME_FORMAT, CultureInfo.CurrentUICulture.DateTimeFormat);
                    }
                    else
                    {
                        name = value.ToString();
                    }
                }

                // custom value text for Light Response Curve
                if (key == SensorPropertyKeys.SENSOR_PROPERTY_LIGHT_RESPONSE_CURVE)
                {
                    if (value is byte[])
                    {
                        byte[] data = value as byte[];
                        // data is a vector of uint (4 byte = 1 uint) that comes in pairs, so must be divisible by 8
                        if (data.Length % 8 == 0)
                        {
                            // use a reader to get uint out of byte[]
                            MemoryStream stream = new MemoryStream(data);
                            BinaryReader reader = new BinaryReader(stream);
                            name = "";
                            int numberPairs = data.Length / 8;
                            for (int i = 0; i < numberPairs; i++)
                            {
                                name = name + "(" + reader.ReadUInt32().ToString() + ", " + reader.ReadUInt32().ToString() + "); ";
                            }

                            reader.Close(); // closes reader and stream
                        }
                    }
                }
            }

            return name;
        }

        /// <summary>
        /// Retrieve a string from KeysNames
        /// </summary>
        /// <param name="key">Key in KeysValuesNames.</param>
        /// <returns>Returns string from KeysNames or the proptery key in string form</returns>
        private static string GetKeyName(PropertyKey key)
        {
            string name = "";

            if (s_keysNames.ContainsKey(key))
            {
                name = s_keysNames[key];
            }
            else
            {
                name = key.fmtid.ToString() + ", " + key.pid.ToString();
            }

            return name;
        }

        /// <summary>
        /// Updates sensor properties and data
        /// </summary>
        private void Update()
        {
            UpdateProperties();
            UpdateData();
        }

        /// <summary>
        /// Updates current properties from the sensor
        /// </summary>
        private void UpdateProperties()
        {
            if (null != m_sensor)
            {
                m_propertiesDictionary = m_sensor.GetAllProperties();
            }
        }

        /// <summary>
        /// Updates current data from the sensor
        /// </summary>
        private void UpdateData()
        {
            if (null != m_sensor)
            {
                try
                {
                    SensorDataReport data = m_sensor.GetDataReport();
                    m_dataDictionary = data.GetDataFields();
                }
                catch (COMException ex)
                {
                    switch (ex.ErrorCode)
                    {
                        case SensorErrors.ERROR_NO_DATA:
                            m_dataDictionary.Clear();
                            m_dataDictionary[SensorErrorValues.ERROR_NO_DATA] = ex.Message;
                            break;
                        default:
                            throw;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    //0x80070005 Access is denied. (E_ACCESSDENIED)
                    m_dataDictionary.Clear();
                    m_dataDictionary[SensorErrorValues.ERROR_ACCESS_DENIED] = ex.Message;
                }
            }
        }

        /// <summary>
        /// Writes logged data from sensor to an initialized log
        /// </summary>
        /// <param name="w">Initialized XmlWriter to be used.</param>
        public void WriteXML(XmlWriter w)
        {
            w.WriteStartElement(SensorXML.SENSOR_DATA);

            w.WriteStartElement(SensorXML.SENSOR_PROPERTIES);
            foreach (KeyValuePair<PropertyKey, object> kvp in m_propertiesDictionary)
            {
                w.WriteStartElement(SensorXML.SENSOR_PROPERTY);
                w.WriteAttributeString(SensorXML.NAME, GetKeyName(kvp.Key));
                w.WriteAttributeString(SensorXML.VALUE, GetKeyValueName(kvp.Key, kvp.Value));
                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteStartElement(SensorXML.SENSOR_DATA_FIELDS);
            foreach (KeyValuePair<PropertyKey, object> kvp in m_dataDictionary)
            {
                w.WriteStartElement(SensorXML.SENSOR_DATA_FIELD);
                w.WriteAttributeString(SensorXML.NAME, GetKeyName(kvp.Key));
                w.WriteAttributeString(SensorXML.VALUE, GetKeyValueName(kvp.Key, kvp.Value));
                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteStartElement(SensorXML.SENSOR_EVENTS);
            foreach (string s in s_enterReports)
            {
                w.WriteStartElement(SensorXML.SENSOR_EVENT);
                w.WriteAttributeString(SensorXML.DATA, s);
                w.WriteEndElement();
            }
            foreach (string s in m_stateReports)
            {
                w.WriteStartElement(SensorXML.SENSOR_EVENT);
                w.WriteAttributeString(SensorXML.DATA, s);
                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteStartElement(SensorXML.SENSOR_DATA_COLLECTION);
            foreach (SensorDataReport r in m_dataReports)
            {
                w.WriteStartElement(SensorXML.DATA_REPORT);
                IDictionary<PropertyKey, object> dataFields = r.GetDataFields();
                foreach (KeyValuePair<PropertyKey, object> dataField in dataFields)
                {
                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, GetKeyName(dataField.Key));
                    w.WriteAttributeString(SensorXML.VALUE, GetKeyValueName(dataField.Key, dataField.Value));
                    w.WriteEndElement();
                }
                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteEndElement();
        }

        /// <summary>
        /// Writes logged data from global events to an initialized log
        /// </summary>
        /// <param name="w">Initialized XmlWriter to be used.</param>
        public static void WriteXMLLocation(XmlWriter w)
        {
            w.WriteStartElement(SensorXML.SENSOR_DATA);

            w.WriteStartElement(SensorXML.SENSOR_EVENTS);
            foreach (string s in s_enterReports)
            {
                w.WriteStartElement(SensorXML.SENSOR_EVENT);
                w.WriteAttributeString(SensorXML.DATA, s);
                w.WriteEndElement();
            }
            foreach (string s in s_locationStatusReports)
            {
                w.WriteStartElement(SensorXML.SENSOR_EVENT);
                w.WriteAttributeString(SensorXML.DATA, s);
                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteStartElement(SensorXML.LOCATION_DATA_COLLECTION);
            foreach (LocationReport r in s_locationReports)
            {
                if (r is CivicAddressLocationReport)
                {
                    w.WriteStartElement(SensorXML.DATA_REPORT);
                    w.WriteAttributeString(SensorXML.TYPE, "CivicAddressReport");
                    CivicAddressLocationReport civic = (CivicAddressLocationReport)r;

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "AddressLine1");
                    w.WriteAttributeString(SensorXML.VALUE, civic.AddressLine1);
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "AddressLine2");
                    w.WriteAttributeString(SensorXML.VALUE, civic.AddressLine2);
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "City");
                    w.WriteAttributeString(SensorXML.VALUE, civic.City);
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "CountryOrRegion");
                    w.WriteAttributeString(SensorXML.VALUE, civic.CountryOrRegion);
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "DetailLevel");
                    w.WriteAttributeString(SensorXML.VALUE, civic.DetailLevel.ToString());
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "PostalCode");
                    w.WriteAttributeString(SensorXML.VALUE, civic.PostalCode);
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "SensorID");
                    w.WriteAttributeString(SensorXML.VALUE, civic.SensorID.ToString());
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "StateOrProvince");
                    w.WriteAttributeString(SensorXML.VALUE, civic.StateOrProvince);
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "Timestamp");
                    w.WriteAttributeString(SensorXML.VALUE, civic.Timestamp.ToString(Constants.TIME_FORMAT, CultureInfo.InvariantCulture.DateTimeFormat));
                    w.WriteEndElement();

                    w.WriteEndElement();
                }
                else if (r is LatLongLocationReport)
                {
                    w.WriteStartElement(SensorXML.DATA_REPORT);
                    w.WriteAttributeString(SensorXML.TYPE, "LatLongReport");
                    LatLongLocationReport latLong = (LatLongLocationReport)r;

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "Altitude");
                    w.WriteAttributeString(SensorXML.VALUE, GetLatLongReportValue(latLong, LatLongReportValue.Altitude));
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "AltitudeError");
                    w.WriteAttributeString(SensorXML.VALUE, GetLatLongReportValue(latLong, LatLongReportValue.AltitudeError));
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "ErrorRadius");
                    w.WriteAttributeString(SensorXML.VALUE, GetLatLongReportValue(latLong, LatLongReportValue.ErrorRadius));
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "Latitude");
                    w.WriteAttributeString(SensorXML.VALUE, GetLatLongReportValue(latLong, LatLongReportValue.Latitude));
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "Longitude");
                    w.WriteAttributeString(SensorXML.VALUE, GetLatLongReportValue(latLong, LatLongReportValue.Longitude));
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "SensorID");
                    w.WriteAttributeString(SensorXML.VALUE, GetLatLongReportValue(latLong, LatLongReportValue.SensorID));
                    w.WriteEndElement();

                    w.WriteStartElement(SensorXML.FIELD);
                    w.WriteAttributeString(SensorXML.NAME, "Timestamp");
                    w.WriteAttributeString(SensorXML.VALUE, GetLatLongReportValue(latLong, LatLongReportValue.Timestamp));
                    w.WriteEndElement();

                    w.WriteEndElement();
                }
            }
            w.WriteEndElement();

            w.WriteEndElement();
        }
    }
}