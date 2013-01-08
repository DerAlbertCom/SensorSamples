using System.IO;
using Windows7.Sensors;

namespace SensorsSample
{
    public class AskByTypeAggregatedSimpleDeviceOrientation : SampleBase
    {
        public override string Desscripion
        {
            get { return "AskByType: AggregatedSimpleDeviceOrientation"; }
        }

        public override void Execute(TextWriter writer, TextReader reader)
        {
            base.Execute(writer, reader);

            var sensors = SensorManager.GetSensorsByType(SensorTypes.AggregatedSimpleDeviceOrientation);
            foreach (var sensor in sensors)
            {
                writer.WriteLine(sensor.FriendlyName);
            }
        }
    }
}