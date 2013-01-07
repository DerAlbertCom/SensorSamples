using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     COM interop wrapper for the ISensorDataReport interface.
    /// </summary>
    [ComImport, Guid("0AB9DF9B-C4B5-4796-8898-0470706A2E1D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISensorDataReport
    {
        /// <summary>
        ///     Get the timestamp for the data report
        /// </summary>
        /// <param name="timeStamp">The timestamp returned for the data report</param>
        void GetTimestamp(out SYSTEMTIME pTimeStamp);

        /// <summary>
        ///     Get a single value reported by the sensor
        /// </summary>
        /// <param name="propKey">The data field ID of interest</param>
        /// <param name="propValue">The data returned</param>
        void GetSensorValue(
            [In] ref PropertyKey pKey,
            out PROPVARIANT pValue);

        // value must be newed before call

        /// <summary>
        ///     Get multiple values reported by a sensor
        /// </summary>
        /// <param name="keys">The collection of keys for values to obtain data for</param>
        /// <param name="values">The values returned by the query</param>
        void GetSensorValues(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues pValues);
    }
}