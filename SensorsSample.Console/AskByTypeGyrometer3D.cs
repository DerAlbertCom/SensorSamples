using System.IO;
using Windows7.Sensors;

namespace SensorsSample
{
    public class AskByTypeGyrometer3D :SampleBase
    {
        public override string Desscripion
        {
            get { return "AskByType: Gyrometer3D"; }
        }

        public override void Execute(TextWriter writer, TextReader reader)
        {
            base.Execute(writer, reader);

            var sensors = SensorManager.GetSensorsByType(SensorTypes.Gyrometer3D);
            foreach (var sensor in sensors)
            {
                writer.WriteLine(sensor.FriendlyName);
            }
        }
    }
}