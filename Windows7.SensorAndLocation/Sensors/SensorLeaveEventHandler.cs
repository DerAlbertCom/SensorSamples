using System;

namespace Windows7.Sensors
{
    /// <summary>
    ///     Handler of sensor detachment/cessation of availability events.
    /// </summary>
    /// <param name="sensor">Sensor for which this event applies.</param>
    /// <param name="sensorID">Sensor instance ID.</param>
    /// <remarks>
    ///     Do not use any sensor property.
    /// </remarks>
    public delegate void SensorLeaveEventHandler(Sensor sensor, Guid sensorID);
}