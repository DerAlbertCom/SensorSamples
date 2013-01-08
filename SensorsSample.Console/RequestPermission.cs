using System;
using System.IO;
using Windows7.Sensors;

namespace SensorsSample
{
    public class RequestPermission : SampleBase
    {
        public override string Desscripion
        {
            get { return "Request Permission"; }
        }
        public override void Execute(TextWriter writer, TextReader reader)
        {
            base.Execute(writer, reader);

            var sensors = SensorManager.GetSensorsByCategory(SensorCategories.Location);
            SensorManager.RequestPermission(IntPtr.Zero, true, sensors);
        }
    }
}