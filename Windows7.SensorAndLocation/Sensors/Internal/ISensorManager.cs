using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     A COM interop wrapper for the ISensorsManager interface
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BD77DB67-45A8-42DC-8D00-6DCF15F8377A")]
    internal interface ISensorManager
    {
        /// <summary>
        ///     Get a collection of related sensors by category, Ex: Light
        /// </summary>
        /// <param name="sensorCategory">The category of sensors to find</param>
        /// <param name="ppSensorsFound">The collection of sensors found</param>
        void GetSensorsByCategory(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid sensorCategory,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISensorCollection ppSensorsFound);

        /// <summary>
        ///     Get sensors by type, Ex: Ambient Light
        /// </summary>
        /// <param name="sensorType">The type of sensors to find</param>
        /// <param name="ppSensorsFound">The collection of sensors found</param>
        void GetSensorsByType(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid sensorType,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISensorCollection ppSensorsFound);

        /// <summary>
        ///     Get a unique instance of a sensor
        /// </summary>
        /// <param name="sensorID">The unique ID of a sensor installed on a system</param>
        /// <param name="ppSensor">The ISensor interface pointer for the sensor found, or null if no sensor was found</param>
        void GetSensorByID(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid sensorID,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISensor ppSensor);

        /// <summary>
        ///     Subscribe to ISensors events
        /// </summary>
        /// <param name="pEvents">An interface pointer to the callback object created</param>
        void SetEventSink(
            [In, MarshalAs(UnmanagedType.Interface)] ISensorManagerEvents pEvents);

        /// <summary>
        ///     Opens a system dialog box to request user permission to access sensor data
        /// </summary>
        /// <param name="parent">HWND handle to a window that can act as a parent to the permissions dialog box</param>
        /// <param name="sensors">Pointer to the ISensorCollection interface that contains the list of sensors for which permission is being requested</param>
        /// <param name="modal">BOOL that specifies the dialog box mode</param>
        void RequestPermissions(
            [In] IntPtr parent,
            [In, MarshalAs(UnmanagedType.Interface)] ISensorCollection sensors,
            [In, MarshalAs(UnmanagedType.Bool)] bool modal);
    }
}