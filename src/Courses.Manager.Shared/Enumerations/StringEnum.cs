using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Courses.Manager.Shared.Enumerations
{
    public static class StringEnum
    {
        private static IDictionary<Enum, StringValueAttribute> _stringValues = new Dictionary<Enum, StringValueAttribute>();

        public static TEnum ConvertToEnum<TEnum, TAttr, TValue>(this TValue value, Func<TAttr, TValue> funcaoSelecao, TEnum valorDefault)
            where TValue : IEquatable<TValue>
            where TEnum : struct, IConvertible
            where TAttr : Attribute
        {
            // CheckEnum<TEnum>();
            Type type = typeof(TEnum);
            Func<TAttr, TValue, bool> AttributeMatch = (attr, val) => (attr != null) && (val.Equals(funcaoSelecao(attr)));

            var fields = (from f in type.GetFields()
                          let attr = (TAttr)f.GetCustomAttributes(typeof(TAttr), false).FirstOrDefault()
                          where AttributeMatch(attr, value)
                          select (TEnum)f.GetValue(default(TEnum)));

            if (fields.Any())
                return fields.First();

            else return valorDefault;
        }

        public static string StringValue(this Enum value)
        {
            if (_stringValues.ContainsKey(value))
                return (_stringValues[value] as StringValueAttribute).ValorString;

            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            if (fi == null)
                return string.Empty;

            StringValueAttribute[] attrs = fi
                .GetCustomAttributes(typeof(StringValueAttribute), false)
                as StringValueAttribute[];

            if (attrs.Length > 0)
            {
                _stringValues[value] = attrs[0];
                return attrs[0].ValorString;
            }

            var attr = fi.GetCustomAttributes(typeof(XmlEnumAttribute), false).FirstOrDefault() as XmlEnumAttribute;
            if (attr != null)
                return attr.Name;

            return value.ToString();
        }
    }
}
