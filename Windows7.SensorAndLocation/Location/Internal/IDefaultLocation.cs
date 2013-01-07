using System;
using System.Runtime.InteropServices;

namespace Windows7.Location.Internal
{
    /// <summary>
    ///     Specifies the default location.
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A65AF77E-969A-4A2E-8ACA-33BB7CBB1235")]
    internal interface IDefaultLocation
    {
        Int32 SetReport([In] ref Guid reportType,
                        [In, MarshalAs(UnmanagedType.Interface)] ILocationReport pLocationReport);

        ILocationReport GetReport([In] ref Guid reportType);
    }
}