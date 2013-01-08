using System.IO;
using Windows7.Sensors;

namespace SensorsSample
{
    public class AskByCategoryOrientation : SampleBase
    {
        public override string Desscripion
        {
            get { return "AskByCategory: Orientation"; }
        }

        public override void Execute(TextWriter writer, TextReader reader)
        {
            base.Execute(writer, reader);
            var sensors = SensorManager.GetSensorsByCategory(SensorCategories.Orientation);
            foreach (var sensor in sensors)
            {
                writer.WriteLine(sensor.FriendlyName);
            }
        }
    }


}