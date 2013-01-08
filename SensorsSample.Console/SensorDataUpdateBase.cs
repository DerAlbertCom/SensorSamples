using System;
using System.Collections.Generic;
using System.IO;
using Windows7.Sensors;

namespace SensorsSample
{
    public abstract class SensorDataUpdateBase : SampleBase
    {
        protected void AttachEvents(TextWriter writer, IEnumerable<Sensor> sensors)
        {
            foreach (var sensor in sensors)
            {
                SensorOnDataUpdated(writer, sensor, sensor.GetDataReport());
                sensor.EventReceived += (sensor1, id, report) => SensorOnEventReceived(writer, sensor1, id, report);
                sensor.DataUpdated += (sensor1, report) => SensorOnDataUpdated(writer, sensor1, report);
            }
        }

        private void SensorOnDataUpdated(TextWriter writer, Sensor sensor, SensorDataReport dataReport)
        {
            foreach (var dataField in dataReport.GetDataFields())
            {
                writer.WriteLine("DataUpdated: {0}", sensor.FriendlyName);
                writer.WriteLine("{0} = {1}", dataField.Key, dataField.Value);
            }
        }

        private void SensorOnEventReceived(TextWriter writer, Sensor sensor, Guid eventId, SensorDataReport dataReport)
        {
            foreach (var dataField  in dataReport.GetDataFields())
            {
                writer.WriteLine("Event: {0}: {1} => {2} {3}",sensor.FriendlyName,eventId,dataField.Key,dataField.Value);
            }   
        }
    }
}