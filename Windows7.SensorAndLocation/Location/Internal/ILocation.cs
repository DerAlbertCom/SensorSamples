using System;
using System.Runtime.InteropServices;

namespace Windows7.Location.Internal
{
    /// <summary>
    ///     COM interface for getting/registering/querying status of reports.
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AB2ECE69-56D9-4F28-B525-DE1B0EE44237")]
    internal interface ILocation
    {
        Int32 RegisterForReport([In, MarshalAs(UnmanagedType.Interface)] ILocationEvents pEvents,
                                [In] ref Guid reportType,
                                [In] uint dwMinReportInterval);

        Int32 UnregisterForReport([In] ref Guid reportType);

        Int32 GetReport([In] ref Guid reportType,
                        [MarshalAs(UnmanagedType.Interface)] out ILocationReport locationReport);

        [PreserveSig]
        Int32 GetReportStatus([In] ref Guid reportType, out ReportStatus pStatus);

        Int32 GetReportInterval([In] ref Guid reportType, out UInt32 reportInterval);

        Int32 SetReportInterval([In] ref Guid reportType, [In] UInt32 milliseconds);

        Int32 GetDesiredAccuracy([In] ref Guid reportType, out DesiredAccuracy desiredAccuracy);

        Int32 SetDesiredAccuracy([In] ref Guid reportType, [In] DesiredAccuracy desiredAccuracy);

        [PreserveSig]
        Int32 RequestPermissions([In] IntPtr hParent, [In] Guid[] pReportTypes, [In] uint count, [In] int fModal);
    }
}