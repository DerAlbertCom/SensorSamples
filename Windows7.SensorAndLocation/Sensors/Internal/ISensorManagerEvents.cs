// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;


namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     A COM interop events interface for the ISensorManager object
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9B3B0B86-266A-4AAD-B21F-FDE5501001B7")]
    internal interface ISensorManagerEvents
    {
        void OnSensorEnter(
            [In, MarshalAs(UnmanagedType.Interface)] ISensor pSensor,
            [In, MarshalAs(UnmanagedType.U4)] SensorState state);
    }
}