using System;

namespace Windows7.Sensors
{
    /// <summary>
    ///     Structure containing the property ID (key) and value.
    /// </summary>
    public struct DataFieldInfo : IEquatable<DataFieldInfo>
    {
        readonly PropertyKey propKey;
        readonly object value;

        /// <summary>
        ///     Constructs the structure.
        /// </summary>
        /// <param name="propKey">Property ID (key).</param>
        /// <param name="value">Property value. Type must be valid for the ID.</param>
        public DataFieldInfo(PropertyKey propKey, object value)
        {
            this.propKey = propKey;
            this.value = value;
        }

        /// <summary>
        ///     Returns the property key.
        /// </summary>
        public PropertyKey Key
        {
            get { return propKey; }
        }

        /// <summary>
        ///     Returns property's value.
        /// </summary>
        public object Value
        {
            get { return value; }
        }

        public override int GetHashCode()
        {
            int valHashCode = value != null ? value.GetHashCode() : 0;
            return propKey.GetHashCode() ^ valHashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is DataFieldInfo))
                return false;

            var other = (DataFieldInfo) obj;
            return value.Equals(other.value) && propKey.Equals(other.propKey);
        }

        public static bool operator ==(DataFieldInfo a, DataFieldInfo b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(DataFieldInfo a, DataFieldInfo b)
        {
            return !a.Equals(b);
        }

        #region IEquatable<DataFieldInfo> Members

        public bool Equals(DataFieldInfo other)
        {
            return value.Equals(other.value) && propKey.Equals(other.propKey);
        }

        #endregion
    }
}