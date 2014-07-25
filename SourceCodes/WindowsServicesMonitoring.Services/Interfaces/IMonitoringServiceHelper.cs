using Aliencube.WindowsServicesMonitoring.Configurations;
using Aliencube.WindowsServicesMonitoring.ViewModels;
using System;
using System.Collections.Generic;

namespace Aliencube.WindowsServicesMonitoring.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>MonitoringServiceHelper</c> class.
    /// </summary>
    public interface IMonitoringServiceHelper : IDisposable
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serviceName">Service name.</param>
        /// <returns>Returns the service.</returns>
        ServiceViewModel GetService(string serverName, string serviceName);

        /// <summary>
        /// Gets the list of <c>ServiceElement</c> instances on the specified server.
        /// </summary>
        /// <param name="server"><c>ServerElement</c> instance.</param>
        /// <returns>Returns the list of <c>ServiceElement</c> instances.</returns>
        IEnumerable<ServiceElement> GetServicesOnServer(ServerElement server);

        /// <summary>
        /// Gets the list of <c>ServerElement</c> instances on the specified environment.
        /// </summary>
        /// <param name="environment"><c>EnvironmentElement</c> instance.</param>
        /// <returns>Returns the list of <c>ServerElement</c> instances.</returns>
        IEnumerable<ServerElement> GetServersOnEnvironment(EnvironmentElement environment);

        /// <summary>
        /// Gets the list of <c>EnvironmentElement</c> instances from the configuration settings.
        /// </summary>
        /// <returns>Returns the list of <c>EnvironmentElement</c> instances.</returns>
        IEnumerable<EnvironmentElement> GetEnvironments();
    }
}