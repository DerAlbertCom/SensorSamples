using System;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     Data associated with a sensor type GUID.
    /// </summary>
    internal struct SensorTypeData
    {
        readonly SensorDescriptionAttribute _sda;
        readonly Type _sensorType;

        public SensorTypeData(Type sensorClassType, SensorDescriptionAttribute sda)
        {
            _sensorType = sensorClassType;
            _sda = sda;
        }

        public Type SensorType
        {
            get { return _sensorType; }
        }


        public SensorDescriptionAttribute Attr
        {
            get { return _sda; }
        }
    }
}