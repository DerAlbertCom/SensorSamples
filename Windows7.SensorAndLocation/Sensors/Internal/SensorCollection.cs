// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using REFSENSOR_ID = System.Guid;
using ULONG = System.UInt32;


namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     A COM interop wrapper for the SensorCollection class
    /// </summary>
    [ComImport, Guid("79C43ADB-A429-469F-AA39-2F2B74B75937"), ClassInterface(ClassInterfaceType.None),
     TypeLibType(TypeLibTypeFlags.FCanCreate)]
    internal class SensorCollection : ISensorCollection
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetAt([In] ULONG index, [MarshalAs(UnmanagedType.Interface)] out ISensor ppSensor);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetCount(out ULONG pCount);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Add([MarshalAs(UnmanagedType.Interface)] ISensor pSensor);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Remove([MarshalAs(UnmanagedType.Interface)] ISensor pSensor);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void RemoveByID([In, MarshalAs(UnmanagedType.LPStruct)] REFSENSOR_ID sensorId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Clear();
    }
}