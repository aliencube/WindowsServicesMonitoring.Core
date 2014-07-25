using Aliencube.WindowsServicesMonitoring.ViewModels;
using System;

namespace Aliencube.WindowsServicesMonitoring.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>MonitoringService</c> class.
    /// </summary>
    public interface IMonitoringService : IDisposable
    {
        /// <summary>
        /// Gets the <c>MonitoringServiceViewModel</c> instance.
        /// </summary>
        /// <returns>Returns the <c>MonitoringServiceViewModel</c> instance.</returns>
        MonitoringServiceViewModel GetMonitoringService();
    }
}