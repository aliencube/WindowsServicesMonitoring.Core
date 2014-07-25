using System.Configuration;

namespace Aliencube.WindowsServicesMonitoring.Configurations
{
    /// <summary>
    /// This represents the server element entity.
    /// </summary>
    public class ServerElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Gets or sets the collection of service elements.
        /// </summary>
        [ConfigurationProperty("services", IsRequired = true)]
        public ServiceElementCollection Services
        {
            get { return (ServiceElementCollection)this["services"]; }
            set { this["services"] = value; }
        }
    }
}