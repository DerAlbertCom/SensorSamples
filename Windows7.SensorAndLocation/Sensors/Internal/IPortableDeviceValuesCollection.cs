using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     Holds a collection of indexed IPortableDeviceValues interfaces. This interface can be
    ///     retrieved from a method, or if a new object is required, call CoCreate with
    ///     CLSID_PortableDeviceValuesCollection.
    /// </summary>
    [ComImport, Guid("6E3F2D79-4E07-48C4-8208-D8C2E5AF4A99"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceValuesCollection
    {
        /// <summary>
        ///     Retrieves the number of items in the collection.
        /// </summary>
        /// <param name="pcElems">Pointer to a DWORD that contains the number of IPortableDeviceValues interfaces in the collection.</param>
        void GetCount([In] ref uint pcElems);

        /// <summary>
        ///     Retrieves an item from the collection by a zero-based index.
        /// </summary>
        /// <param name="dwIndex">DWORD that specifies a zero-based index in the collection.</param>
        /// <param name="ppValues">Address of a variable that receives a pointer to an IPortableDeviceValues interface from the collection. The caller is responsible for calling Release on this interface when done with it</param>
        void GetAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

        /// <summary>
        ///     Adds an item to the collection.
        /// </summary>
        /// <param name="pValues">Pointer to an IPortableDeviceValues interface to add to the collection. The interface is not actually copied, but AddRef is called on it</param>
        void Add([In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues);

        /// <summary>
        ///     Releases all items from the collection.
        /// </summary>
        void Clear();

        /// <summary>
        ///     Removes an item from the collection by a zero-based index.
        /// </summary>
        /// <param name="dwIndex">DWORD that specifies a zero-based index in the collection.</param>
        void RemoveAt([In] uint dwIndex);
    }
}