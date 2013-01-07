// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using Windows7.Sensors.Internal;


namespace Windows7.Sensors
{
    /// <summary>
    ///     A base-class for sensor data reports. Contains methods which derived types can use to expose values in a friendly an type-safe manner.
    /// </summary>
    public abstract class SensorDataReport
    {
        ISensorDataReport _iSensorReport;
        Sensor _sensor;

        /// <summary>
        ///     Retrieves the sensor object which generated this report.
        /// </summary>
        protected Sensor Sensor
        {
            get { return _sensor; }
        }

        /// <summary>
        ///     Retrieves the time at which the data report was created.
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                SYSTEMTIME sTime;
                _iSensorReport.GetTimestamp(out sTime);
                return sTime.DateTime;
            }
        }

        internal void InitializeReport(ISensorDataReport report, Sensor sensor)
        {
            _iSensorReport = report;
            _sensor = sensor;
            Initialize();
        }

        protected abstract void Initialize();

        /// <summary>
        ///     Returns the property IDs and values for all data contained in this data report.
        /// </summary>
        /// <returns>A dictionary mapping property IDs to values.</returns>
        public IDictionary<PropertyKey, object> GetDataFields()
        {
            var reportData = new Dictionary<PropertyKey, object>();
            IPortableDeviceValues valuesCollection;
            _iSensorReport.GetSensorValues(null, out valuesCollection);

            uint nItems = 0;
            valuesCollection.GetCount(ref nItems);
            for (uint i = 0; i < nItems; i++)
            {
                var propKey = new PropertyKey();
                var propValue = new PROPVARIANT();
                valuesCollection.GetAt(i, ref propKey, out propValue);

                try
                {
                    reportData.Add(propKey, propValue.Value);
                }
                finally
                {
                    propValue.Clear();
                }
            }

            return reportData;
        }

        /// <summary>
        ///     Returns the property value for the given property ID.
        /// </summary>
        /// <param name="propKey">Property ID.</param>
        /// <returns>A value (may be of various types).</returns>
        public object GetDataField(PropertyKey propKey)
        {
            var propVal = new PROPVARIANT();

            try
            {
                _iSensorReport.GetSensorValue(ref propKey, out propVal);
                return propVal.Value;
            }
            finally
            {
                propVal.Clear();
            }
        }
    }
}