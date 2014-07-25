using System;

namespace Aliencube.WindowsServicesMonitoring.Configurations.Interfaces
{
    /// <summary>
    /// This provides interfaces to the MonitoringSettingsSection class.
    /// </summary>
    public interface IMonitoringSettingsSection : IDisposable
    {
        /// <summary>
        /// Gets or sets the collection of environment elements.
        /// </summary>
        EnvironmentElementCollection Environments { get; set; }
    }
}