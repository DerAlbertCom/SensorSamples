// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;


namespace Windows7.Sensors
{
    /// <summary>
    ///     Handler for sensor attachment/availability events.
    /// </summary>
    /// <param name="sensor">Sensor for which this event applies.</param>
    /// <param name="state">New state of the sensor.</param>
    public delegate void SensorEnterEventHandler(Sensor sensor, SensorState state);
}