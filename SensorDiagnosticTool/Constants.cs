// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using Windows7.Sensors;


namespace SensorDiagnosticTool
{
    /// <summary>
    /// General WPD Property Keys
    /// </summary>
    public static class WPDPropertyKeys
    {
        private static readonly Guid WPD_OBJECT_PROPERTIES_V1 = new Guid(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C);
        public static readonly PropertyKey WPD_OBJECT_ID = PropertyKey.Create(WPD_OBJECT_PROPERTIES_V1, 2);
        public static readonly PropertyKey WPD_OBJECT_PARENT_ID = PropertyKey.Create(WPD_OBJECT_PROPERTIES_V1, 3);
        public static readonly PropertyKey WPD_OBJECT_NAME = PropertyKey.Create(WPD_OBJECT_PROPERTIES_V1, 4);
        public static readonly PropertyKey WPD_OBJECT_PERSISTENT_UNIQUE_ID = PropertyKey.Create(WPD_OBJECT_PROPERTIES_V1, 5);
        public static readonly PropertyKey WPD_OBJECT_FORMAT = PropertyKey.Create(WPD_OBJECT_PROPERTIES_V1, 6);
        public static readonly PropertyKey WPD_OBJECT_CONTENT_TYPE = PropertyKey.Create(WPD_OBJECT_PROPERTIES_V1, 7);
        
        public static readonly PropertyKey WPD_OBJECT_CAN_DELETE = PropertyKey.Create(WPD_OBJECT_PROPERTIES_V1, 26);

        private static readonly Guid WPD_FUNCTIONAL_OBJECT_PROPERTIES_V1 = new Guid(0x8F052D93, 0xABCA, 0x4FC5, 0xA5, 0xAC, 0xB0, 0x1D, 0xF4, 0xDB, 0xE5, 0x98);
        public static readonly PropertyKey WPD_FUNCTIONAL_OBJECT_CATEGORY = PropertyKey.Create(WPD_FUNCTIONAL_OBJECT_PROPERTIES_V1, 2);
    }

    /// <summary>
    /// Sensor error values
    /// </summary>
    public static class SensorErrorValues
    {
        // Property Keys are random GUIDs not associated with SensorAPI, used just for this application
        public static readonly PropertyKey ERROR_NO_DATA = PropertyKey.Create("{BD61CB73-DB2B-4927-B33A-674DE2F8BC32}", 0);
        public static readonly PropertyKey ERROR_ACCESS_DENIED = PropertyKey.Create("{BD61CB73-DB2B-4927-B33A-674DE2F8BC32}", 1);
    }

    public static class SensorErrors
    {
        public const int ERROR_NO_DATA = unchecked((int)0x800700E8);
        public const int TYPE_E_TYPEMISMATCH = unchecked((int)0x80028CA0);
        public const int ERROR_NOT_FOUND = unchecked((int)0x80070490);
    }

    public static class Constants
    {
        public const string TIME_FORMAT = "o";
    }

    public static class SensorXML
    {
        public const string SENSOR_DATA = "SensorData";
        public const string SENSOR_PROPERTIES = "SensorProperties";
        public const string SENSOR_PROPERTY = "SensorProperty";
        public const string NAME = "name";
        public const string VALUE = "value";
        public const string SENSOR_DATA_FIELDS = "SensorDataFields";
        public const string SENSOR_DATA_FIELD = "SensorDataField";
        public const string SENSOR_EVENTS = "SensorEvents";
        public const string SENSOR_EVENT = "SensorEvent";
        public const string DATA = "data";
        public const string SENSOR_DATA_COLLECTION = "SensorDataCollection";
        public const string DATA_REPORT = "DataReport";
        public const string FIELD = "Field";
        public const string TYPE = "type";
        public const string LOCATION_DATA_COLLECTION = "LocationDataCollection";
        public const string SENSOR_DIAGNOSTIC_TOOL = "SensorDiagnosticTool";
        public const string VERSION = "version";
        public const string VERSION_NUMBER = "0.1";
    }
}