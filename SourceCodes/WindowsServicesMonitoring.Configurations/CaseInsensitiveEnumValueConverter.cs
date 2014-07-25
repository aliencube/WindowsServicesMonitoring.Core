using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace Aliencube.WindowsServicesMonitoring.Configurations
{
    /// <summary>
    /// This represents a converter entity to convert string to enum value.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    public class CaseInsensitiveEnumValueConverter<T> : ConfigurationConverterBase
    {
        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context"><c>ITypeDescriptorContext</c> that provides a format context.</param>
        /// <param name="culture"><c>CultureInfo</c> to use as the current culture.</param>
        /// <param name="value"><c>Object</c> to convert.</param>
        /// <returns>Returns the <c>Object</c> that represents the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return Enum.Parse(typeof(T), (string)value, true);
        }
    }
}