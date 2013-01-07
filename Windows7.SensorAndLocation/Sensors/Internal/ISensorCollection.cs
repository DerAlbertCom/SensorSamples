using System;
using System.Runtime.InteropServices;

namespace Windows7.Sensors.Internal
{
    /// <summary>
    ///     A COM interop wrapper for the ISensorCollection interface
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("23571E11-E545-4DD8-A337-B89BF44B10DF")]
    internal interface ISensorCollection
    {
        /// <summary>
        ///     Get a sensor by index
        /// </summary>
        /// <param name="ulIndex">The index for the sensor to retrieve</param>
        /// <param name="ppSensor">The sensor retrieved</param>
        void GetAt([In] UInt32 ulIndex, [Out] out ISensor ppSensor);

        /// <summary>
        ///     Get the sensor count for the collection
        /// </summary>
        /// <param name="pCount">The count returned</param>
        void GetCount([Out] out UInt32 pCount);

        /// <summary>
        ///     Add a sensor to the collection
        /// </summary>
        /// <param name="pSensor">The sensor to add</param>
        void Add([In, MarshalAs(UnmanagedType.IUnknown)] ISensor pSensor);

        /// <summary>
        ///     Remove a sensor from the collection
        /// </summary>
        /// <param name="pSensor">The sensor to remove</param>
        void Remove([In] ISensor pSensor);

        /// <summary>
        ///     Remove a sensor from the collection
        /// </summary>
        /// <param name="sensorID">Remove sensor by ID</param>
        void RemoveByID([In, MarshalAs(UnmanagedType.LPStruct)] Guid sensorID);

        /// <summary>
        ///     Clear the collection
        /// </summary>
        void Clear();
    }
}