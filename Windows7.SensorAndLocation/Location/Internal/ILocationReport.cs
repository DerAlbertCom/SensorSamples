// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows7.Sensors;
using Windows7.Sensors.Internal;


namespace Windows7.Location.Internal
{
    /// <summary>
    ///     COM interface for the base report.
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("C8B7F7EE-75D0-4DB9-B62D-7A0F369CA456")]
    internal interface ILocationReport
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Guid GetSensorID();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        SYSTEMTIME GetTimestamp();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetValue([In] ref PropertyKey pKey, out PROPVARIANT pValue);
    }
}