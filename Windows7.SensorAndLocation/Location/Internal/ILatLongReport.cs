using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows7.Sensors;
using Windows7.Sensors.Internal;

namespace Windows7.Location.Internal
{
    /// <summary>
    ///     COM interface for the latitude/longitude/altitude report.
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7FED806D-0EF8-4F07-80AC-36A0BEAE3134")]
    internal interface ILatLongReport : ILocationReport
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new Guid GetSensorID();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new SYSTEMTIME GetTimestamp();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetValue([In] ref PropertyKey pKey, out PROPVARIANT pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        double GetLatitude();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        double GetLongitude();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        double GetErrorRadius();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        double GetAltitude();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        double GetAltitudeError();
    }
}