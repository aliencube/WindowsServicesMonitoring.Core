using System.ComponentModel;
using System.Configuration;
using System.ServiceProcess;

namespace Aliencube.WindowsServicesMonitoring.Configurations
{
    /// <summary>
    /// This represents the service element entity.
    /// </summary>
    public class ServiceElement : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Gets or sets the service status expected.
        /// </summary>
        [ConfigurationProperty("expected", IsRequired = true)]
        [TypeConverter(typeof(CaseInsensitiveEnumValueConverter<ServiceControllerStatus>))]
        public ServiceControllerStatus Expected
        {
            get { return (ServiceControllerStatus)this["expected"]; }
            set { this["expected"] = value; }
        }

        /// <summary>
        /// Gets or sets the username to run the service, if necessary.
        /// </summary>
        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        /// <summary>
        /// Gets or sets the password to run the service, if necessary.
        /// </summary>
        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        #endregion Properties
    }
}