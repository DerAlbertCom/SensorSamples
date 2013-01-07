using System;

namespace Windows7.Sensors
{
    /// <summary>
    ///     Handler of new data event.
    /// </summary>
    /// <param name="sensor">Sensor for which this event applies.</param>
    /// <param name="dataReport">Data report for the sensor. You should cast it to a appropriate derived type.</param>
    public delegate void SensorDataUpdatedEventHandler(Sensor sensor, SensorDataReport dataReport);
}