// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using REFSENSOR_CATEGORY_ID = System.Guid;
using REFSENSOR_ID = System.Guid;
using REFSENSOR_TYPE_ID = System.Guid;


namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     A COM interop wrapper for the SensorsManager class
    /// </summary>
    /// <remarks>
    ///     See Sensor API documentation in Windows 7 SDK
    /// </remarks>
    [ComImport, Guid("77A1C827-FCD2-4689-8915-9D613CC5FA3E"), ClassInterface(ClassInterfaceType.None)]
    internal class SensorManager : ISensorManager
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetSensorsByCategory(
            [In, MarshalAs(UnmanagedType.LPStruct)] REFSENSOR_CATEGORY_ID sensorCategory,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISensorCollection ppSensorsFound);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetSensorsByType(
            [In, MarshalAs(UnmanagedType.LPStruct)] REFSENSOR_TYPE_ID sensorType,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISensorCollection ppSensorsFound);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetSensorByID(
            [In, MarshalAs(UnmanagedType.LPStruct)] REFSENSOR_ID sensorID,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISensor ppSensor);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetEventSink(
            [Out, MarshalAs(UnmanagedType.Interface)] ISensorManagerEvents pEvents);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void RequestPermissions(
            IntPtr hParent,
            [In, MarshalAs(UnmanagedType.Interface)] ISensorCollection pSensors,
            [In, MarshalAs(UnmanagedType.Bool)] bool modal);
    }
}