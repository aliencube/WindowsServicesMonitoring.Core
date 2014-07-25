using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Aliencube.WindowsServicesMonitoring.Configurations.Extensions
{
    /// <summary>
    /// This represents the entity to extend the <c>ConfigurationElementCollection</c> class.
    /// </summary>
    public static class ConfigurationElementCollectionExtension
    {
        /// <summary>
        /// Converts the <c>ConfigurationElementCollection</c> instance to <c>IEnumerable</c>.
        /// </summary>
        /// <typeparam name="TElement"><c>ConfigurationElement</c> type.</typeparam>
        /// <typeparam name="TElementCollection"><c>ConfigurationElementCollection</c> type.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<TElement> AsEnumerable<TElement, TElementCollection>(this TElementCollection value)
            where TElement : ConfigurationElement
            where TElementCollection : ConfigurationElementCollection
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var elements = value.Cast<TElement>();
            return elements;
        }
    }
}