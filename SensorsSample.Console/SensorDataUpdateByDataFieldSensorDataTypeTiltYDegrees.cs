using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows7.Sensors;

namespace SensorsSample
{
    public class SensorDataUpdateByDataFieldSensorDataTypeTiltYDegrees : SensorDataUpdateBase
    {
        public override string Desscripion
        {
            get { return "SensorDataUpdateByDataField: SENSOR_DATA_TYPE_TILT_Y_DEGREES"; }
        }

        public override void Execute(TextWriter writer, TextReader reader)
        {
            base.Execute(writer, reader);
            // crash
            //var sensors =
            //    SensorManager.GetAllSensors()
            //                 .Where(s => s.SupportsDataField(SensorPropertyKeys.SENSOR_DATA_TYPE_TILT_Y_DEGREES));
            var sensors = SensorManager.GetAllSensors().Where(s => s.GetSupportedDataFields()
                                                                    .ToList()
                                                                    .Contains(SensorPropertyKeys.SENSOR_DATA_TYPE_TILT_Y_DEGREES))
                                                           .ToList();
            AttachEvents(writer, sensors);
            reader.Read();
        }
    }
}