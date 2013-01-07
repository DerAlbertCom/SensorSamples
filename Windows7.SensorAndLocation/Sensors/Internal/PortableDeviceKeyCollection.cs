// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Windows7.Sensors.Internal
{
    [ComImport, Guid("DE2D022D-2480-43BE-97F0-D1FA2CF98F4F"), ClassInterface(ClassInterfaceType.None),
     TypeLibType(TypeLibTypeFlags.FCanCreate)]
    internal class PortableDeviceKeyCollection : IPortableDeviceKeyCollection
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetCount(out UInt32 pcElems);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetAt([In] UInt32 dwIndex, out PropertyKey pKey);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Add([In] ref PropertyKey Key);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Clear();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void RemoveAt([In] UInt32 dwIndex);
    }
}