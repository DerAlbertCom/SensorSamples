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

        static readonly Guid SENSOR_DATA_TYPE_COMMON_GUID = new Guid(0XDB5E0CF2, 0XCF1F, 0X4C18, 0XB4, 0X6C, 0XD8, 0X60,
                                                                     0X11,
                                                                     0XD6, 0X21, 0X50);

        static readonly Guid SENSOR_DATA_TYPE_MOTION_GUID = new Guid(0X3F8A69A2, 0X7C5, 0X4E48, 0XA9, 0X65, 0XCD, 0X79,
                                                                     0X7A, 0XAB, 0X56, 0XD5);


        static readonly Guid SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID = new Guid(0X38564A7C, 0XF2F2, 0X49BB, 0X9B, 0X2B,
                                                                              0XBA, 0X60,
                                                                              0XF6, 0X6A, 0X58, 0XDF);

        static readonly Guid SENSOR_DATA_TYPE_BIOMETRIC_GUID = new Guid(0X2299288A, 0X6D9E, 0X4B0B, 0XB7, 0XEC, 0X35,
                                                                        0X28,
                                                                        0XF8, 0X9E, 0X40, 0XAF);

        static readonly Guid SENSOR_DATA_TYPE_SCANNER_GUID = new Guid(0XD7A59A3C, 0X3421, 0X44AB, 0X8D, 0X3A, 0X9D, 0XE8,
                                                                      0XAB, 0X6C, 0X4C, 0XAE);

        static readonly Guid SENSOR_DATA_TYPE_LIGHT_GUID = new Guid(0XE4C77CE2, 0XDCB7, 0X46E9, 0X84, 0X39, 0X4F,
                                                                    0XEC, 0X54, 0X88, 0X33, 0XA6);

        static readonly Guid SENSOR_DATA_TYPE_LOCATION_GUID = new Guid(0X055C74D8, 0XCA6F, 0X47D6, 0X95, 0XC6, 0X1E,
                                                                       0XD3, 0X63, 0X7A, 0X0F, 0XF4);

        static readonly Guid SENSOR_DATA_TYPE_ENVIRONMENTAL_GUID = new Guid(0X8B0AA2F1, 0X2D57, 0X42EE, 0X8C, 0XC0, 0X4D,
                                                                            0X27, 0X62, 0X2B, 0X46, 0XC4);

        static readonly Guid SENSOR_DATA_TYPE_ORIENTATION_GUID = new Guid(0X1637D8A2, 0X4248, 0X4275, 0X86, 0X5D, 0X55, 0X8D, 0XE8, 0X4A, 0XED, 0XFD);

        static readonly Guid SENSOR_DATA_TYPE_ELECTRICAL_GUID = new Guid(0XBBB246D1, 0XE242, 0X4780, 0XA2, 0XD3, 0XCD,
                                                                         0XED, 0X84, 0XF3, 0X58, 0X42);


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
            PropertyKey.Create(SENSOR_DATA_TYPE_COMMON_GUID, 2);

        /// <summary>
        ///     The sensor latitude in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_LATITUDE_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 2);

        /// <summary>
        ///     The sensor longitude in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_LONGITUDE_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 3);

        /// <summary>
        ///     The sensor altitude from sea level in meters property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_SEALEVEL_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 4);

        /// <summary>
        ///     The sensor altitude in meters property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_ELLIPSOID_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 5);

        /// <summary>
        ///     The sensor speed in knots property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SPEED_KNOTS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 6);

        /// <summary>
        ///     The sensor true heading in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_TRUE_HEADING_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 7);

        /// <summary>
        ///     The sensor magnetic heading in degrees property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_DEGREES =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 8);

        /// <summary>
        ///     The sensor magnetic variation property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_VARIATION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 9);

        /// <summary>
        ///     The sensor data fix quality property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_FIX_QUALITY =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 10);

        /// <summary>
        ///     The sensor data fix type property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_FIX_TYPE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 11);

        /// <summary>
        ///     The sensor position dilution of precision property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_POSITION_DILUTION_OF_PRECISION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 12);

        /// <summary>
        ///     The sensor horizontal dilution of precision property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_HORIZONAL_DILUTION_OF_PRECISION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 13);

        /// <summary>
        ///     The sensor vertical dilution of precision property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_VERTICAL_DILUTION_OF_PRECISION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 14);

        /// <summary>
        ///     The sensor number of satelites used property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_USED_COUNT =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 15);

        /// <summary>
        ///     The sensor number of satelites used property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_USED_PRNS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 16);

        /// <summary>
        ///     The sensor view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 17);

        /// <summary>
        ///     The sensor view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_PRNS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 18);

        /// <summary>
        ///     The sensor elevation property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_ELEVATION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 19);

        /// <summary>
        ///     The sensor azimuth value for satelites in view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_AZIMUTH =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 20);

        /// <summary>
        ///     The sensor signal to noise ratio for satelites in view property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_STN_RATIO =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 21);

        /// <summary>
        ///     The sensor accuracy of latitude and longitude values.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ERROR_RADIUS_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 22);

        /// <summary>
        ///     The first line of the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ADDRESS1 =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 23);

        /// <summary>
        ///     The second line of the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ADDRESS2 =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 24);

        /// <summary>
        ///     The city in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_CITY =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 25);

        /// <summary>
        ///     The state/province in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_STATE_PROVINCE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 26);

        /// <summary>
        ///     The postal code in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_POSTALCODE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 27);

        /// <summary>
        ///     The country/region in the civic address.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_COUNTRY_REGION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 28);

        /// <summary>
        ///     Altitude Error with regards to ellipsoid, in meters
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_ELLIPSOID_ERROR_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 29);

        /// <summary>
        ///     Altitude Error with regards to sea level, in meters
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_SEALEVEL_ERROR_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 30);

        public static readonly PropertyKey SENSOR_DATA_TYPE_GPS_SELECTION_MODE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 31);

        public static readonly PropertyKey SENSOR_DATA_TYPE_GPS_OPERATION_MODE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 32);

        public static readonly PropertyKey SENSOR_DATA_TYPE_GPS_STATUS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 33);

        public static readonly PropertyKey SENSOR_DATA_TYPE_GEOIDAL_SEPARATION =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 34);

        public static readonly PropertyKey SENSOR_DATA_TYPE_DGPS_DATA_AGE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 35);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ALTITUDE_ANTENNA_SEALEVEL_METERS =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 36);

        public static readonly PropertyKey SENSOR_DATA_TYPE_DIFFERENTIAL_REFERENCE_STATION_ID =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 37);

        public static readonly PropertyKey SENSOR_DATA_TYPE_NMEA_SENTENCE =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 38);

        public static readonly PropertyKey SENSOR_DATA_TYPE_SATELLITES_IN_VIEW_ID =
            PropertyKey.Create(SENSOR_DATA_TYPE_LOCATION_GUID, 39);

        /// <summary>
        ///     The sensor temperature in celsius property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_TEMPERATURE_CELSIUS =
            PropertyKey.Create(SENSOR_DATA_TYPE_ENVIRONMENTAL_GUID, 2);

        public static readonly PropertyKey SENSOR_DATA_TYPE_RELATIVE_HUMIDITY_PERCENT =
            PropertyKey.Create(SENSOR_DATA_TYPE_ENVIRONMENTAL_GUID, 3);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ATMOSPHERIC_PRESSURE_BAR =
            PropertyKey.Create(SENSOR_DATA_TYPE_ENVIRONMENTAL_GUID, 4);

        public static readonly PropertyKey SENSOR_DATA_TYPE_WIND_DIRECTION_DEGREES_ANTICLOCKWISE =
            PropertyKey.Create(SENSOR_DATA_TYPE_ENVIRONMENTAL_GUID, 5);

        public static readonly PropertyKey SENSOR_DATA_TYPE_WIND_SPEED_METERS_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_ENVIRONMENTAL_GUID, 6);

        /// <summary>
        ///     The sensor gravitational acceleration (X-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ACCELERATION_X_G =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 2);

        /// <summary>
        ///     The sensor gravitational acceleration (Y-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ACCELERATION_Y_G =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 3);

        /// <summary>
        ///     The sensor gravitational acceleration (Z-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ACCELERATION_Z_G =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 4);

        /// <summary>
        ///     The sensor angular acceleration per second (X-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_X_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 5);

        /// <summary>
        ///     The sensor angular acceleration per second (Y-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Y_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 6);

        /// <summary>
        ///     The sensor angular acceleration per second (Z-axis) property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_ACCELERATION_Z_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 7);


        public static readonly PropertyKey SENSOR_DATA_TYPE_SPEED_METERS_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 8);

        public static readonly PropertyKey SENSOR_DATA_TYPE_MOTION_STATE =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 9);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_VELOCITY_X_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 10);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_VELOCITY_Y_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 11);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ANGULAR_VELOCITY_Z_DEGREES_PER_SECOND =
            PropertyKey.Create(SENSOR_DATA_TYPE_MOTION_GUID, 12);

        public static readonly PropertyKey SENSOR_DATA_TYPE_BOOLEAN_SWITCH_STATE =
            PropertyKey.Create(SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID, 2);

        /// <summary>
        ///     The sensor multi-value switch data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_MULTIVALUE_SWITCH_STATE =
            PropertyKey.Create(SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID, 3);

        /// <summary>
        ///     The sensor boolean switch array state data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_BOOLEAN_SWITCH_ARRAY_STATE =
            PropertyKey.Create(SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID, 10);

        /// <summary>
        ///     The sensor force (in newtons) data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_FORCE_NEWTONS =
            PropertyKey.Create(SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID, 4);

        /// <summary>
        ///     The sensor weight (in kilograms) data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_WEIGHT_KILOGRAMS =
            PropertyKey.Create(SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID, 5);

        /// <summary>
        ///     The sensor pressure data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_PRESSURE_PASCAL =
            PropertyKey.Create(SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID, 6);

        /// <summary>
        ///     The sensor strain data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_STRAIN =
            PropertyKey.Create(SENSOR_DATA_TYPE_GUID_MECHANICAL_GUID, 7);

        /// <summary>
        ///     The sensor human presence data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_HUMAN_PRESENCE =
            PropertyKey.Create(SENSOR_DATA_TYPE_BIOMETRIC_GUID, 2);

        /// <summary>
        ///     The sensor human proximity data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_HUMAN_PROXIMITY =
            PropertyKey.Create(SENSOR_DATA_TYPE_BIOMETRIC_GUID, 3);

        /// <summary>
        ///     The sensor light data property key.
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_LIGHT_LUX =
            PropertyKey.Create(SENSOR_DATA_TYPE_LIGHT_GUID, 2);

        public static readonly PropertyKey SENSOR_DATA_TYPE_LIGHT_TEMPERATURE_KELVIN =
            PropertyKey.Create(SENSOR_DATA_TYPE_LIGHT_GUID, 3);

        public static readonly PropertyKey SENSOR_DATA_TYPE_LIGHT_CHROMACITY =
            PropertyKey.Create(SENSOR_DATA_TYPE_LIGHT_GUID, 4);

        /// <summary>
        ///     The sensor 40-bit RFID tag data property key.
        /// 
        /// </summary>
        public static readonly PropertyKey SENSOR_DATA_TYPE_RFID_TAG_40_BIT =
            PropertyKey.Create(SENSOR_DATA_TYPE_SCANNER_GUID, 2);

        public static readonly PropertyKey SENSOR_DATA_TYPE_VOLTAGE_VOLTS =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 2);

        public static readonly PropertyKey SENSOR_DATA_TYPE_CURRENT_AMPS =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 3);

        public static readonly PropertyKey SENSOR_DATA_TYPE_CAPACITANCE_FARAD =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 4);

        public static readonly PropertyKey SENSOR_DATA_TYPE_RESISTANCE_OHMS =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 5);

        public static readonly PropertyKey SENSOR_DATA_TYPE_INDUCTANCE_HENRY =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 6);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ELECTRICAL_POWER_WATTS =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 7);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ELECTRICAL_PERCENT_OF_RANGE =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 8);

        public static readonly PropertyKey SENSOR_DATA_TYPE_ELECTRICAL_FREQUENCY_HERTZ =
            PropertyKey.Create(SENSOR_DATA_TYPE_ELECTRICAL_GUID, 9);

        public static readonly PropertyKey SENSOR_DATA_TYPE_TILT_X_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 2);
        public static readonly PropertyKey SENSOR_DATA_TYPE_TILT_Y_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 3);
        public static readonly PropertyKey SENSOR_DATA_TYPE_TILT_Z_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 4);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_X_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 5);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_Y_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 6);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_Z_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 7);
        public static readonly PropertyKey SENSOR_DATA_TYPE_DISTANCE_X_METERS = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 8);
        public static readonly PropertyKey SENSOR_DATA_TYPE_DISTANCE_Y_METERS = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 9);
        public static readonly PropertyKey SENSOR_DATA_TYPE_DISTANCE_Z_METERS = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 10);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_COMPENSATED_MAGNETIC_NORTH_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 11);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_COMPENSATED_TRUE_NORTH_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 12);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_MAGNETIC_NORTH_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 13);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_HEADING_TRUE_NORTH_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 14);
        public static readonly PropertyKey SENSOR_DATA_TYPE_QUADRANT_ANGLE_DEGREES = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 15);
        public static readonly PropertyKey SENSOR_DATA_TYPE_ROTATION_MATRIX = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 16);
        public static readonly PropertyKey SENSOR_DATA_TYPE_QUATERNION = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 17);
        public static readonly PropertyKey SENSOR_DATA_TYPE_SIMPLE_DEVICE_ORIENTATION = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 18);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_FIELD_STRENGTH_X_MILLIGAUSS = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 19);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_FIELD_STRENGTH_Y_MILLIGAUSS = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 20);
        public static readonly PropertyKey SENSOR_DATA_TYPE_MAGNETIC_FIELD_STRENGTH_Z_MILLIGAUSS = PropertyKey.Create(SENSOR_DATA_TYPE_ORIENTATION_GUID, 21);

    }
}