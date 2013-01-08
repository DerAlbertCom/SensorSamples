using System.IO;

namespace SensorsSample
{
    public interface ISample
    {
        string Desscripion { get; }
        void Execute(TextWriter writer, TextReader unknown);
    }
}