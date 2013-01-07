// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;

namespace Windows7.Sensors
{
    /// <summary>
    ///     Sensor Property Key identifiers. This class will be removed once wrappers are developed.
    /// </summary>
    public static class SensorPropertyKeys
    {
        /// <summary>
        ///     The common Guid used by the property keys.
        /// </summary>
        static readonly Guid SENSOR_PROPERTY_COMMON_GUID = new Guid(0X7F8383EC, 0XD3EC, 0X495C, 0XA8, 0XCF, 0XB8, 0XBB,
                                                                    0XE8, 0X5C, 0X29, 0X20);

        static readonly Guid SENSOR_DATA_TYPE_COMMON = new Guid(0XDB5E0CF2, 0XCF1F, 0X4C18, 0XB4, 0X6C, 0XD8, 0X60, 0X11,
                                                                0XD6, 0X21, 0X50);

        static readonly Guid SENSOR_DATA_TYPE_MOTION_COMMON = new Guid(0X3F8A69A2, 0X7C5, 0X4E48, 0XA9, 0X65, 0XCD, 0X79,
                                                                       0X7A, 0XAB, 0X56, 0XD5);

        static readonly Guid SENSOR_DATA_TYPE_POSITION_COMMON = new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35,
                                                                         0X2A, 0X95, 0X82, 0X81, 0X9D);

        static readonly Guid SENSOR_DATA_TYPE_FORCE_COMMON = new Guid(0X38564A7C, 0XF2F2, 0X49BB, 0X9B, 0X2B, 0XBA, 0X60,
                                                                      0XF6, 0X6A, 0X58, 0XDF);

        static readonly Guid SENSOR_DATA_TYPE_PROXIMITY = new Guid(0X2299288A, 0X6D9E, 0X4B0B, 0XB7, 0XEC, 0X35, 0X28,
                                                                   0XF8, 0X9E, 0X40, 0XAF);

        static readonly Guid SENSOR_DATA_TYPE_RFID_COMMON = new Guid(0XD7A59A3C, 0X3421, 0X44AB, 0X8D, 0X3A, 0X9D, 0XE8,
                                                                     0XAB, 0X6C, 0X4C, 0XAE);

        static readonly Guid SENSOR_DATA_TYPE_AMBIENT_COMMON = new Guid(0XE4C77CE2, 0XDCB7, 0X46E9, 0X84, 0X39, 0X4F,
                                                                        0XEC, 0X54, 0X88, 0X33, 0XA6);

        static readonly Guid SENSOR_DATA_TYPE_LOCATION_COMMON = new Guid(0X055C74D8, 0XCA6F, 0X47D6, 0X95, 0XC6, 0X1E,
                                                                         0XD3, 0X63, 0X7A, 0X0F, 0XF4);

        static readonly Guid SENSOR_DATA_TYPE_TEMPERATURE_COMMON = new Guid(0X8B0AA2F1, 0X2D57, 0X42EE, 0X8C, 0XC0, 0X4D, 0X27, 0X62, 0X2B, 0X46, 0XC4);

        /// <summary>
        ///     The sensor type property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_TYPE = PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 2);

        /// <summary>
        ///     The sensor state property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_STATE = PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 3);

        /// <summary>
        ///     The sensor sampling rate property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_SAMPLING_RATE =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 4);

        /// <summary>
        ///     The sensor persistent unique id property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_PERSISTENT_UNIQUE_ID =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 5);

        /// <summary>
        ///     The sensor manufacturer property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_MANUFACTURER = PropertyKey.Create(
            SENSOR_PROPERTY_COMMON_GUID, 6);

        /// <summary>
        ///     The sensor model property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_MODEL = PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 7);

        /// <summary>
        ///     The sensor serial number property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_SERIAL_NUMBER =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 8);

        /// <summary>
        ///     The sensor friendly name property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_FRIENDLY_NAME =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 9);

        /// <summary>
        ///     The sensor description property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_DESCRIPTION = PropertyKey.Create(
            SENSOR_PROPERTY_COMMON_GUID, 10);

        /// <summary>
        ///     The sensor connection type property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_CONNECTION_TYPE =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 11);

        /// <summary>
        ///     The sensor min report interval property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_MIN_REPORT_INTERVAL =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 12);

        /// <summary>
        ///     The sensor current report interval property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_CURRENT_REPORT_INTERVAL =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 13);

        /// <summary>
        ///     The sensor change sensitivity property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_CHANGE_SENSITIVITY =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 14);

        /// <summary>
        ///     The sensor device id property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_DEVICE_ID = PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID,
                                                                                          15);

        /// <summary>
        ///     The sensor light response curve property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_LIGHT_RESPONSE_CURVE =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 16);

        /// <summary>
        ///     The sensor accuracy property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_ACCURACY = PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 17);

        /// <summary>
        ///     The sensor resolution property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_RESOLUTION = PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID,
                                                                                           18);

        /// <summary>
        ///     The sensor location desired accuracy property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_LOCATION_DESIRED_ACCURACY =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 19);

        /// <summary>
        ///     The sensor range minimum property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_RANGE_MINIMUM =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 20);

        /// <summary>
        ///     The sensor range maximum property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_PROPERTY_RANGE_MAXIMUM =
            PropertyKey.Create(SENSOR_PROPERTY_COMMON_GUID, 21);

        /// <summary>
        ///     The sensor date time property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_TIMESTAMP =
            PropertyKey.Create(SENSOR_DATA_TYPE_COMMON, 2);

        /// <summary>
        ///     The sensor latitude in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_LATITUDE_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 2);

        /// <summary>
        ///     The sensor longitude in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_LONGITUDE_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 3);

        /// <summary>
        ///     The sensor altitude from sea level in meters property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_SEALEVEL_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 4);

        /// <summary>
        ///     The sensor altitude in meters property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_ELLIPSOID_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 5);

        /// <summary>
        ///     The sensor speed in knots property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SPEED_KNOTS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 6);

        /// <summary>
        ///     The sensor true heading in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_TRUE_HEADING_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 7);

        /// <summary>
        ///     The sensor magnetic heading in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 8);

        /// <summary>
        ///     The sensor magnetic variation property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_VARIATION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 9);

        /// <summary>
        ///     The sensor data fix quality property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_FIX_QUALITY =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 10);

        /// <summary>
        ///     The sensor data fix type property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_FIX_TYPE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 11);

        /// <summary>
        ///     The sensor position dilution of precision property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_POSITION_DILUTION_OF_PRECISION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 12);

        /// <summary>
        ///     The sensor horizontal dilution of precision property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_HORIZONAL_DILUTION_OF_PRECISION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 13);

        /// <summary>
        ///     The sensor vertical dilution of precision property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_VERTICAL_DILUTION_OF_PRECISION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 14);

        /// <summary>
        ///     The sensor number of satelites used property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_USED_COUNT =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 15);

        /// <summary>
        ///     The sensor number of satelites used property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_USED_PRNS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 16);

        /// <summary>
        ///     The sensor view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 17);

        /// <summary>
        ///     The sensor view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_PRNS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 18);

        /// <summary>
        ///     The sensor elevation property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_ELEVATION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 19);

        /// <summary>
        ///     The sensor azimuth value for satelites in view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_AZIMUTH =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 20);

        /// <summary>
        ///     The sensor signal to noise ratio for satelites in view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_STN_RATIO =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 21);

        /// <summary>
        ///     The sensor accuracy of latitude and longitude values.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ERROR_RADIUS_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 22);

        /// <summary>
        ///     The first line of the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ADDRESS1 =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 23);

        /// <summary>
        ///     The second line of the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ADDRESS2 =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 24);

        /// <summary>
        ///     The city in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_CITY =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 25);

        /// <summary>
        ///     The state/province in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_STATE_PROVINCE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 26);

        /// <summary>
        ///     The postal code in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_POSTALCODE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 27);

        /// <summary>
        ///     The country/region in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_COUNTRY_REGION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 28);

        /// <summary>
        ///     Altitude Error with regards to ellipsoid, in meters
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_ELLIPSOID_ERROR_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 29);

        /// <summary>
        ///     Altitude Error with regards to sea level, in meters
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_SEALEVEL_ERROR_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_COMMON, 30);

        /// <summary>
        ///     The sensor temperature in celsius property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_TEMPERATURE_CELSIUS =
            PropertyKey.Create(SENSOR_DATA_TYPE_TEMPERATURE_COMMON, 2);

        /// <summary>
        ///     The sensor gravitational acceleration (X-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ACCELERATION_X_G =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_COMMON, 2);

        /// <summary>
        ///     The sensor gravitational acceleration (Y-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ACCELERATION_Y_G =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_COMMON, 3);

        /// <summary>
        ///     The sensor gravitational acceleration (Z-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ACCELERATION_Z_G =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_COMMON, 4);

        /// <summary>
        ///     The sensor angular acceleration per second (X-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_X_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_COMMON, 5);

        /// <summary>
        ///     The sensor angular acceleration per second (Y-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Y_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_COMMON, 6);

        /// <summary>
        ///     The sensor angular acceleration per second (Z-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Z_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_COMMON, 7);

        /// <summary>
        ///     The sensor angle in degrees (X-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGLE_X_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 2);

        /// <summary>
        ///     The sensor angle in degrees (Y-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGLE_Y_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 3);

        /// <summary>
        ///     The sensor angle in degrees (Z-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGLE_Z_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 4);

        /// <summary>
        ///     The sensor magnetic heading (X-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_X_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 5);

        /// <summary>
        ///     The sensor magnetic heading (Y-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_Y_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 6);

        /// <summary>
        ///     The sensor magnetic heading (Z-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_Z_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 7);

        /// <summary>
        ///     The sensor distance (X-axis) data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_DISTANCE_X_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 8);

        /// <summary>
        ///     The sensor distance (Y-axis) data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_DISTANCE_Y_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 9);

        /// <summary>
        ///     The sensor distance (Z-axis) data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_DISTANCE_Z_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_POSITION_COMMON, 10);

        /// <summary>
        ///     The sensor boolean switch data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_BOOLEAN_SWITCH_STATE =
            PropertyKey.Create(SENSOR_DATA_TYPE_FORCE_COMMON, 2);

        /// <summary>
        ///     The sensor multi-value switch data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MULTIVALUE_SWITCH_STATE =
            PropertyKey.Create(SENSOR_DATA_TYPE_FORCE_COMMON, 3);

        /// <summary>
        ///     The sensor boolean switch array state data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_BOOLEAN_SWITCH_ARRAY_STATE =
            PropertyKey.Create(SENSOR_DATA_TYPE_FORCE_COMMON, 10);

        /// <summary>
        ///     The sensor force (in newtons) data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_FORCE_NEWTONS =
            PropertyKey.Create(SENSOR_DATA_TYPE_FORCE_COMMON, 4);

        /// <summary>
        ///     The sensor weight (in kilograms) data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_WEIGHT_KILOGRAMS =
            PropertyKey.Create(SENSOR_DATA_TYPE_FORCE_COMMON, 5);

        /// <summary>
        ///     The sensor pressure data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_PRESSURE_PASCAL =
            PropertyKey.Create(SENSOR_DATA_TYPE_FORCE_COMMON, 6);

        /// <summary>
        ///     The sensor strain data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_STRAIN =
            PropertyKey.Create(SENSOR_DATA_TYPE_FORCE_COMMON, 7);

        /// <summary>
        ///     The sensor human presence data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_HUMAN_PRESENCE =
            PropertyKey.Create(SENSOR_DATA_TYPE_PROXIMITY, 2);

        /// <summary>
        ///     The sensor human proximity data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_HUMAN_PROXIMITY =
            PropertyKey.Create(SENSOR_DATA_TYPE_PROXIMITY, 3);

        /// <summary>
        ///     The sensor light data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_LIGHT_LUX =
            PropertyKey.Create(SENSOR_DATA_TYPE_AMBIENT_COMMON, 2);

        /// <summary>
        ///     The sensor 40-bit RFID tag data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_RFID_TAG_40_BIT =
            PropertyKey.Create(SENSOR_DATA_TYPE_RFID_COMMON, 2);

    }
}