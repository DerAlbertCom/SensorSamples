using System;

namespace Windows7.Sensors.Internal
{
    internal class SensorManagerEventSink : ISensorManagerEvents
    {
        #region ISensorManagerEventsInternal Members

        public void OnSensorEnter(ISensor pSensor, SensorState state)
        {
            Windows7.Sensors.SensorManager.OnSensorEnter(pSensor, state);
        }

        #endregion
    }
}