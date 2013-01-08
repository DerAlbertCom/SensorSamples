using System;
using System.Device.Location;

namespace SensorsSample
{
    public class DeviceLocationGeoCoordinateWatcher : SampleBase
    {
        public override string Desscripion
        {
            get { return "System.Device.Location GeoCoordinateWatcher"; }
        }

        public override void Execute(System.IO.TextWriter writer, System.IO.TextReader reader)
        {
            base.Execute(writer, reader);
            var watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged +=
                (sender, args) =>
                    {
                        writer.WriteLine("The Current Position is {0}/{1}",
                                         args.Position.Location.Latitude,
                                         args.Position.Location.Longitude);
                    };
            watcher.Start();
            reader.Read();
            watcher.Stop();
            watcher.Dispose();
        }
    }

    public class DeviceLocationGeoCivicAddressResolver : SampleBase
    {
        public override string Desscripion
        {
            get { return "System.Device.Location CivicAddressResolver"; }
        }

        public override void Execute(System.IO.TextWriter writer, System.IO.TextReader reader)
        {
            base.Execute(writer, reader);
            var watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            var lockObject = new object();
            watcher.Start();
            watcher.PositionChanged +=
                (sender, args) =>
                    {
                        lock (lockObject)
                        {
                            writer.WriteLine("Status: {0}", watcher.Status);
                            var resolver = new CivicAddressResolver();
                            GeoCoordinate location = args.Position.Location;
                            writer.WriteLine("The Current Location is {0}/{1}",
                                             args.Position.Location.Latitude,
                                             args.Position.Location.Longitude);
                            if (location.IsUnknown)
                                writer.WriteLine("Unbekannte Position")
                            else
                            {
                                // funktioniert nicht, externe API einsetzen
                                var adress = resolver.ResolveAddress(location);
                                writer.WriteLine("Line1: {0}", adress.AddressLine1);
                                writer.WriteLine("Line2: {0}", adress.AddressLine2);
                                writer.WriteLine("PostalCode: {0}", adress.PostalCode);
                                writer.WriteLine("City: {0}", adress.City);
                                writer.WriteLine("Country: {0}", adress.CountryRegion);
                            }
                        }
                    };
            watcher.Start();
            reader.Read();
            watcher.Stop();
            watcher.Dispose();
        }
    }
}