using System;

namespace Windows7.Sensors
{
    /// <summary>
    ///     Handler of sensor state changes events.
    /// </summary>
    /// <param name="sensor">Sensor for which this event applies.</param>
    /// <param name="state">New state of the sensor.</param>
    public delegate void SensorStateChangedEventHandler(Sensor sensor, SensorState state);
}