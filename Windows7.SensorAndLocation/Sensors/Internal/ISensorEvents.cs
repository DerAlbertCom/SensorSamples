using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     A COM interop events interface for the ISensor object
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5D8DCC91-4641-47E7-B7C3-B74F48A6C391")]
    internal interface ISensorEvents
    {
        void OnStateChanged(
            [In, MarshalAs(UnmanagedType.Interface)] ISensor sensor,
            [In, MarshalAs(UnmanagedType.U4)] SensorState state);

        void OnDataUpdated(
            [In, MarshalAs(UnmanagedType.Interface)] ISensor sensor,
            [In, MarshalAs(UnmanagedType.Interface)] ISensorDataReport newData);

        void OnEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ISensor sensor,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventId,
            [In, MarshalAs(UnmanagedType.Interface)] ISensorDataReport newData);

        void OnLeave([In, MarshalAs(UnmanagedType.LPStruct)] Guid sensorId);
    }
}