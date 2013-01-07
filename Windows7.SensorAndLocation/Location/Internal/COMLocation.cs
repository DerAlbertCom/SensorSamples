// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DWORD = System.UInt32;
using HRESULT = System.Int32;

namespace Windows7.Location.Internal
{
    /// <summary>
    ///     COM wrapper for getting/registering/querying status of reports.
    /// </summary>
    [ComImport, Guid("E5B8E079-EE6D-4E33-A438-C87F2E959254"), ClassInterface(ClassInterfaceType.None)]
    internal class COMLocation : ILocation
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT RegisterForReport(
            [In, MarshalAs(UnmanagedType.Interface)] ILocationEvents pEvents,
            [In] ref Guid reportType,
            [In] uint dwMinReportInterval);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT UnregisterForReport([In] ref Guid reportType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetReport([In] ref Guid reportType,
                                                [MarshalAs(UnmanagedType.Interface)] out ILocationReport locationReport);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetReportStatus([In] ref Guid reportType, out ReportStatus pStatus);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetReportInterval([In] ref Guid reportType, out DWORD reportInterval);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetReportInterval([In] ref Guid reportType, [In] DWORD milliseconds);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetDesiredAccuracy([In] ref Guid reportType, out DesiredAccuracy pStatus);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetDesiredAccuracy([In] ref Guid reportType, [In] DesiredAccuracy pStatus);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT RequestPermissions([In] IntPtr hParent,
                                                         [In] Guid[] pReportTypes,
                                                         [In] uint count,
                                                         [In] int fModal);
    }
}