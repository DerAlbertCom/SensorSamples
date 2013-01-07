using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     The IPortableDeviceValues interface holds a collection of PROPERTYKEY/PROPVARIANT pairs.
    ///     Values in the collection do not need to be all the same VARTYPE. Values are stored as key-value
    ///     pairs; each key must be unique in the collection. Clients can search for items by PROPERTYKEY
    ///     or zero-based index. Data values are stored as PROPVARIANT structures. You can add or retrieve
    ///     values of any type by using the generic methods SetValue and GetValue, or you add items by using
    ///     the method specific to the type of data added.
    /// </summary>
    [ComImport, Guid("6848F6F2-3155-4F86-B6F5-263EEEAB3143"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceValues
    {
        void GetCount([In] ref uint pcelt);
        void GetAt([In] uint index, [In, Out] ref PropertyKey pKey, out PROPVARIANT pValue);
        void SetValue([In] ref PropertyKey key, [In] ref PROPVARIANT pValue);
        void GetValue([In] ref PropertyKey key, out PROPVARIANT pValue);
        void SetStringValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.LPWStr)] string Value);
        void GetStringValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.LPWStr)] out string pValue);
        void SetUnsignedIntegerValue([In] ref PropertyKey key, [In] uint Value);
        void GetUnsignedIntegerValue([In] ref PropertyKey key, out uint pValue);
        void SetSignedIntegerValue([In] ref PropertyKey key, [In] int Value);
        void GetSignedIntegerValue([In] ref PropertyKey key, out int pValue);
        void SetUnsignedLargeIntegerValue([In] ref PropertyKey key, [In] ulong Value);
        void GetUnsignedLargeIntegerValue([In] ref PropertyKey key, out ulong pValue);
        void SetSignedLargeIntegerValue([In] ref PropertyKey key, [In] long Value);
        void GetSignedLargeIntegerValue([In] ref PropertyKey key, out long pValue);
        void SetFloatValue([In] ref PropertyKey key, [In] float Value);
        void GetFloatValue([In] ref PropertyKey key, out float pValue);
        void SetErrorValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Error)] int Value);
        void GetErrorValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Error)] out int pValue);
        void SetKeyValue([In] ref PropertyKey key, [In] ref PropertyKey Value);
        void GetKeyValue([In] ref PropertyKey key, out PropertyKey pValue);
        void SetBoolValue([In] ref PropertyKey key, [In] int Value);
        void GetBoolValue([In] ref PropertyKey key, out int pValue);
        void SetIUnknownValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.IUnknown)] object pValue);
        void GetIUnknownValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.IUnknown)] out object ppValue);
        void SetGuidValue([In] ref PropertyKey key, [In] ref Guid Value);
        void GetGuidValue([In] ref PropertyKey key, out Guid pValue);
        void SetBufferValue([In] ref PropertyKey key, [In] byte[] pValue, [In] uint cbValue);
        void GetBufferValue([In] ref PropertyKey key, [Out] IntPtr ppValue, out uint pcbValue);

        void SetIPortableDeviceValuesValue([In] ref PropertyKey key,
                                           [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValue);

        void GetIPortableDeviceValuesValue([In] ref PropertyKey key,
                                           [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValue);

        void SetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key,
                                                          [In, MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pValue);

        void GetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key,
                                                          [MarshalAs(UnmanagedType.Interface)] out
                                                              IPortableDevicePropVariantCollection ppValue);

        void SetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key,
                                                  [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection
                                                      pValue);

        void GetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key,
                                                  [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection
                                                      ppValue);

        void SetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key,
                                                     [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValuesCollection pValue);

        void GetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key,
                                                     [MarshalAs(UnmanagedType.Interface)] out
                                                         IPortableDeviceValuesCollection ppValue);

        void RemoveValue([In] ref PropertyKey key);
        void CopyValuesFromPropertyStore([In, MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);
        void CopyValuesToPropertyStore([In, MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);
        void Clear();
    }
}