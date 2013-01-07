using System;

namespace Windows7.Sensors
{
    /// <summary>
    ///     Handler for a generic/custom event.
    /// </summary>
    /// <param name="sensor">Sensor for which this event applies.</param>
    /// <param name="eventID">Event GUID.</param>
    /// <param name="dataReport">Data report for the sensor. You should cast it to a appropriate derived type.</param>
    public delegate void SensorEventHandler(Sensor sensor, Guid eventID, SensorDataReport dataReport);
}