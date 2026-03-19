using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Music.Application.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                // Try Display attribute
                var displayAttribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                if (displayAttribute != null && !string.IsNullOrEmpty(displayAttribute.Name))
                {
                    return displayAttribute.Name;
                }

                // Try Description attribute
                var descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }

            return value.ToString();
        }
    }
}
