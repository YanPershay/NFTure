using System.ComponentModel;

namespace NFTure.Application
{
    public static class EnumDescriptionExtension
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            throw new ArgumentException("Description not found.", nameof(value));
        }
    }
}
