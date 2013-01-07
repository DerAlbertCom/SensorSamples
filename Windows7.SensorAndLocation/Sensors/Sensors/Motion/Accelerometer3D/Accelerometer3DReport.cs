// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;


namespace Windows7.Sensors.Sensors.Motion
{
    /// <summary>
    ///     Represents a data report coming from <see cref="Accelerometer3D" /> sensor. Provides strongly-typed accessors for data properties.
    /// </summary>
    public class Accelerometer3DReport : SensorDataReport
    {
        /// <summary>
        ///     Acceleration in g's in the X axis.
        /// </summary>
        public float AxisX_G
        {
            get { return (float) GetDataField(SensorPropertyKeys.SENSOR_DATA_TYPE_ACCELERATION_X_G); }
        }

        /// <summary>
        ///     Acceleration in g's in the Y axis.
        /// </summary>
        public float AxisY_G
        {
            get { return (float) GetDataField(SensorPropertyKeys.SENSOR_DATA_TYPE_ACCELERATION_Y_G); }
        }

        /// <summary>
        ///     Acceleration in g's in the Z axis.
        /// </summary>
        public float AxisZ_G
        {
            get { return (float) GetDataField(SensorPropertyKeys.SENSOR_DATA_TYPE_ACCELERATION_Z_G); }
        }

        protected override void Initialize()
        {
        }
    }
}