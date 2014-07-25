using System.Configuration;

namespace Aliencube.WindowsServicesMonitoring.Configurations
{
    /// <summary>
    /// This represents the environment element entity.
    /// </summary>
    public class EnvironmentElement : ConfigurationElement
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
        /// Gets or sets the collection of server elements.
        /// </summary>
        [ConfigurationProperty("servers", IsRequired = true)]
        public ServerElementCollection Servers
        {
            get { return (ServerElementCollection)this["servers"]; }
            set { this["servers"] = value; }
        }
    }
}