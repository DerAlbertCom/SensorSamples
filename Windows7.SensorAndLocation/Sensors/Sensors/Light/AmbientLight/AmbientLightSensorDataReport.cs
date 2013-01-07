// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;

namespace Windows7.Sensors.Sensors.Light
{
    /// <summary>
    ///     Represents a data report coming from <see cref="AmbientLightSensor" /> sensor. Provides strongly-typed accessors for data properties.
    /// </summary>
    public class AmbientLightSensorDataReport : SensorDataReport
    {
        /// <summary>
        ///     Illuminance in units of Lux.
        /// </summary>
        public float IlluminanceLux
        {
            get { return (float) GetDataField(SensorPropertyKeys.SENSOR_DATA_TYPE_LIGHT_LUX); }
        }

        protected override void Initialize()
        {
        }
    }
}