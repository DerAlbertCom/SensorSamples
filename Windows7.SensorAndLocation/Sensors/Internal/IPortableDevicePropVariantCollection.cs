using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     Holds a collection of PROPVARIANT values of the same VARTYPE. The VARTYPE of the first item
    ///     that is added to the collection determines the VARTYPE of the collection. An attempt to add
    ///     an item of a different VARTYPE may fail if the PROPVARIANT value cannot be changed to the
    ///     collection?s current VARTYPE. To change the VARTYPE of the collection manually, call ChangeType
    /// </summary>
    [ComImport, Guid("89B2E422-4F1B-4316-BCEF-A44AFEA83EB3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDevicePropVariantCollection
    {
        void GetCount([In] ref uint pcElems);
        void GetAt([In] uint dwIndex, [In] ref PROPVARIANT pValue);
        void Add([In] ref PROPVARIANT pValue);
        void GetType(out ushort pvt);
        void ChangeType([In] ushort vt);
        void Clear();
        void RemoveAt([In] uint dwIndex);
    }
}