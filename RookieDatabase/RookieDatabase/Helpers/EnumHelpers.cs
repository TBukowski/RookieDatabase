using System;
using System.ComponentModel;
using System.Linq;

namespace RookieDatabase.Helpers
{
    public static class EnumHelpers
    {
        public static string GetDescription<TEnum>(this TEnum value) where TEnum : struct
        {
            var enumType = typeof(TEnum);

            var memInfo = enumType.GetMember(value.ToString()).First();
            var descAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(memInfo, typeof(DescriptionAttribute));
            return descAttribute == null ? value.ToString() : descAttribute.Description;
        }
    }
}
