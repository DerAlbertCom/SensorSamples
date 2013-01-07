using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    [ComImport, Guid("0C15D503-D017-47CE-9016-7B3F978721CC"), ClassInterface(ClassInterfaceType.None),
     TypeLibType(TypeLibTypeFlags.FCanCreate)]
    internal class PortableDeviceValues : IPortableDeviceValues
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetCount([In] ref uint pcelt);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetAt([In] uint index, [In, Out] ref PropertyKey pKey, out PROPVARIANT pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetValue([In] ref PropertyKey key, [In] ref PROPVARIANT pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetValue([In] ref PropertyKey key, out PROPVARIANT pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetStringValue([In] ref PropertyKey key,
                                                  [In, MarshalAs(UnmanagedType.LPWStr)] string Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetStringValue([In] ref PropertyKey key,
                                                  [MarshalAs(UnmanagedType.LPWStr)] out string pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetUnsignedIntegerValue([In] ref PropertyKey key, [In] uint Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetUnsignedIntegerValue([In] ref PropertyKey key, out uint pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetSignedIntegerValue([In] ref PropertyKey key, [In] int Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetSignedIntegerValue([In] ref PropertyKey key, out int pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetUnsignedLargeIntegerValue([In] ref PropertyKey key, [In] ulong Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetUnsignedLargeIntegerValue([In] ref PropertyKey key, out ulong pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetSignedLargeIntegerValue([In] ref PropertyKey key, [In] long Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetSignedLargeIntegerValue([In] ref PropertyKey key, out long pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetFloatValue([In] ref PropertyKey key, [In] float Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetFloatValue([In] ref PropertyKey key, out float pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetErrorValue([In] ref PropertyKey key,
                                                 [In, MarshalAs(UnmanagedType.Error)] int Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetErrorValue([In] ref PropertyKey key,
                                                 [MarshalAs(UnmanagedType.Error)] out int pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetKeyValue([In] ref PropertyKey key, [In] ref PropertyKey Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetKeyValue([In] ref PropertyKey key, out PropertyKey pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetBoolValue([In] ref PropertyKey key, [In] int Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetBoolValue([In] ref PropertyKey key, out int pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetIUnknownValue([In] ref PropertyKey key,
                                                    [In, MarshalAs(UnmanagedType.IUnknown)] object pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetIUnknownValue([In] ref PropertyKey key,
                                                    [MarshalAs(UnmanagedType.IUnknown)] out object ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetGuidValue([In] ref PropertyKey key, [In] ref Guid Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetGuidValue([In] ref PropertyKey key, out Guid pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetBufferValue([In] ref PropertyKey key, [In] byte[] pValue, [In] uint cbValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetBufferValue([In] ref PropertyKey key, [Out] IntPtr ppValue, out uint pcbValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetIPortableDeviceValuesValue([In] ref PropertyKey key,
                                                                 [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetIPortableDeviceValuesValue([In] ref PropertyKey key,
                                                                 [MarshalAs(UnmanagedType.Interface)] out
                                                                     IPortableDeviceValues ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key,
                                                                                [In, MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection
                                                                                    pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key,
                                                                                [MarshalAs(UnmanagedType.Interface)] out
                                                                                    IPortableDevicePropVariantCollection
                                                                                    ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key,
                                                                        [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key,
                                                                        [MarshalAs(UnmanagedType.Interface)] out
                                                                            IPortableDeviceKeyCollection ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key,
                                                                           [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValuesCollection pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key,
                                                                           [MarshalAs(UnmanagedType.Interface)] out
                                                                               IPortableDeviceValuesCollection ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void RemoveValue([In] ref PropertyKey key);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CopyValuesFromPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CopyValuesToPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Clear();
    }
}