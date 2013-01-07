using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     Exposes methods for enumerating, getting, and setting property values.
    /// </summary>
    [ComImport, Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPropertyStore
    {
        void GetCount(out uint cProps);
        void GetAt([In] uint iProp, out PropertyKey pKey);
        void GetValue([In] ref PropertyKey key, out PROPVARIANT pv);
        void SetValue([In] ref PropertyKey key, [In] ref PROPVARIANT propvar);
        void Commit();
    }
}