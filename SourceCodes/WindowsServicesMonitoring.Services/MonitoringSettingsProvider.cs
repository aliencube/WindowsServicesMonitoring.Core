using Aliencube.WindowsServicesMonitoring.Configurations;
using Aliencube.WindowsServicesMonitoring.Configurations.Interfaces;
using Aliencube.WindowsServicesMonitoring.Services.Interfaces;

namespace Aliencube.WindowsServicesMonitoring.Services
{
    /// <summary>
    /// This represents the monitoring settings section provider entity.
    /// </summary>
    public class MonitoringSettingsProvider : IMonitoringSettingsProvider
    {
        private readonly IMonitoringSettingsSection _settings;

        /// <summary>
        /// Initialises a new instance of the MonitoringSettingsProvider class.
        /// </summary>
        public MonitoringSettingsProvider()
        {
            this._settings = MonitoringSettingsSection.CreateInstance();
        }

        /// <summary>
        /// Gets the collection of environment elements.
        /// </summary>
        public EnvironmentElementCollection Environments
        {
            get { return this._settings.Environments; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}