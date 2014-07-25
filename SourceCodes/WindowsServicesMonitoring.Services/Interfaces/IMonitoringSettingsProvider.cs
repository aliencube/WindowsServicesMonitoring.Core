using Aliencube.WindowsServicesMonitoring.Configurations;
using System;

namespace Aliencube.WindowsServicesMonitoring.Services.Interfaces
{
    public interface IMonitoringSettingsProvider : IDisposable
    {
        /// <summary>
        /// Gets the collection of environment elements.
        /// </summary>
        EnvironmentElementCollection Environments { get; }
    }
}