using System.IO;

namespace SensorsSample
{
    public abstract  class SampleBase : ISample
    {

        public abstract string Desscripion { get; }

        public virtual void Execute(TextWriter writer, TextReader reader)
        {
            writer.WriteLine("Sample: {0}", Desscripion);
            writer.WriteLine("---------------");
        }
    }
}