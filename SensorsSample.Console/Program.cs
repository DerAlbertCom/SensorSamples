using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorsSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IList<ISample> samples = typeof (Program).Assembly.GetExportedTypes()
                                                     .Where(t => typeof(ISample).IsAssignableFrom(t) && !t.IsAbstract)
                                                     .Select(Activator.CreateInstance).Cast<ISample>()
                                                     .ToList();
            while (true)
            {
                Console.Clear();
                PrintSamples(samples);
                var line = Console.ReadLine().Trim();
                if (line == "exit" || line == "quit")
                {
                    break;
                }
                if (ExecuteSample(line, samples))
                    Console.ReadKey();
            }
        }

        private static bool ExecuteSample(string line, IList<ISample> samples)
        {
            int i;
            if (!int.TryParse(line, out i))
                return false;
            if (i + 1 > samples.Count)
                return false;
            samples[i].Execute(Console.Out, Console.In);
            return true;
        }

        private static void PrintSamples(IList<ISample> samples)
        {
            for (var i = 0; i < samples.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, samples[i].Desscripion);
            }
        }
    }
}