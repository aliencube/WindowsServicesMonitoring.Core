using Aliencube.WindowsServicesMonitoring.Configurations.Interfaces;
using System.Configuration;

namespace Aliencube.WindowsServicesMonitoring.Configurations
{
    /// <summary>
    /// This represents the web monitoring configuration section entity.
    /// </summary>
    public class MonitoringSettingsSection : ConfigurationSection, IMonitoringSettingsSection
    {
        #region Properties

        /// <summary>
        /// Gets or sets the collection of environment elements.
        /// </summary>
        [ConfigurationProperty("environments", IsRequired = true)]
        public EnvironmentElementCollection Environments
        {
            get { return (EnvironmentElementCollection)this["environments"]; }
            set { this["environments"] = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the instance of the MonitoringSettingsSection class.
        /// </summary>
        /// <returns></returns>
        public static IMonitoringSettingsSection CreateInstance()
        {
            var settings = ConfigurationManager.GetSection("monitoringSettings") as MonitoringSettingsSection;
            return settings;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion Methods
    }
}