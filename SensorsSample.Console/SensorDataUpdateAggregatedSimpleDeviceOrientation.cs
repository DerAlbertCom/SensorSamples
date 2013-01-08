using System.IO;
using Windows7.Sensors;

namespace SensorsSample
{
    public class SensorDataUpdateAggregatedSimpleDeviceOrientation : SensorDataUpdateBase
    {
        public override string Desscripion
        {
            get { return "SensorDataUpdate: AggregatedSimpleDeviceOrientation"; }
        }

        public override void Execute(TextWriter writer, TextReader reader)
        {
            base.Execute(writer, reader);

            var sensors = SensorManager.GetSensorsByType(SensorTypes.AggregatedSimpleDeviceOrientation);
            AttachEvents(writer, sensors);
            reader.Read();
        }
    }
}