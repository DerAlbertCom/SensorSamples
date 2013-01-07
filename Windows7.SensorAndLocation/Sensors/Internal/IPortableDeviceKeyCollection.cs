using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     Holds a collection of PROPERTYKEY values. This interface can be retrieved from a method
    ///     or, if a new object is required, call CoCreate with CLSID_PortableDeviceKeyCollection.
    /// </summary>
    [ComImport, Guid("DADA2357-E0AD-492E-98DB-DD61C53BA353"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceKeyCollection
    {
        void GetCount(out UInt32 pcElems);
        void GetAt([In] UInt32 dwIndex, out PropertyKey pKey);
        void Add([In] ref PropertyKey Key);
        void Clear();
        void RemoveAt([In] UInt32 dwIndex);
    }
}