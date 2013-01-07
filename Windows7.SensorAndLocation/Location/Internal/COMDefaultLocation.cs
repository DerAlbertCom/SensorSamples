// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HRESULT = System.Int32;

namespace Windows7.Location.Internal
{
    /// <summary>
    ///     COM wrapper for getting and setting the default location.
    /// </summary>
    [ComImport, Guid("8B7FBFE0-5CD7-494A-AF8C-283A65707506"), ClassInterface(ClassInterfaceType.None)]
    internal class COMDefaultLocation : IDefaultLocation
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern ILocationReport GetReport([In] ref Guid reportType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetReport([In] ref Guid reportType,
                                                [In, MarshalAs(UnmanagedType.Interface)] ILocationReport pLocationReport);
    }
}