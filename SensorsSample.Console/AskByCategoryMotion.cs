using System.IO;
using Windows7.Sensors;

namespace SensorsSample
{
    public class AskByCategoryMotion : SampleBase
    {
        public override string Desscripion
        {
            get { return "AskByCategory: Motion"; }
        }

        public override void Execute(TextWriter writer, TextReader reader)
        {
            base.Execute(writer, reader);
            var sensors = SensorManager.GetSensorsByCategory(SensorCategories.Motion);
            foreach (var sensor in sensors)
            {
                writer.WriteLine(sensor.FriendlyName);
            }
        }
    }
}