using Aliencube.WindowsServicesMonitoring.Configurations;
using Aliencube.WindowsServicesMonitoring.Configurations.Extensions;
using Aliencube.WindowsServicesMonitoring.Services.Interfaces;
using Aliencube.WindowsServicesMonitoring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Aliencube.WindowsServicesMonitoring.Services
{
    /// <summary>
    /// This represents the helper entity for the <c>MonitoringService</c> class.
    /// </summary>
    public class MonitoringServiceHelper : IMonitoringServiceHelper
    {
        private readonly IMonitoringSettingsProvider _settings;

        /// <summary>
        /// Initialises a new instance of the MonitoringServiceHelper class.
        /// </summary>
        /// <param name="settings"><c>MonitoringSettingsProvider</c> instance.</param>
        public MonitoringServiceHelper(IMonitoringSettingsProvider settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            this._settings = settings;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serviceName">Service name.</param>
        /// <returns>Returns the service.</returns>
        public ServiceViewModel GetService(string serverName, string serviceName)
        {
            if (String.IsNullOrWhiteSpace(serverName))
            {
                throw new ArgumentNullException("serverName");
            }

            if (String.IsNullOrWhiteSpace(serviceName))
            {
                throw new ArgumentNullException("serviceName");
            }

            var service = ServiceController.GetServices(serverName)
                                           .SingleOrDefault(svc =>
                                                            String.Equals(svc.ServiceName, serviceName,
                                                                          StringComparison.InvariantCultureIgnoreCase));
            if (service == null)
            {
                return null;
            }

            var vm = new ServiceViewModel() { Name = service.ServiceName, Service = service };
            return vm;
        }

        /// <summary>
        /// Gets the list of <c>ServiceElement</c> instances on the specified server.
        /// </summary>
        /// <param name="server"><c>ServerElement</c> instance.</param>
        /// <returns>Returns the list of <c>ServiceElement</c> instances.</returns>
        public IEnumerable<ServiceElement> GetServicesOnServer(ServerElement server)
        {
            if (server == null)
            {
                throw new ArgumentNullException("server");
            }

            var services = server.Services.AsEnumerable<ServiceElement, ServiceElementCollection>();
            return services;
        }

        /// <summary>
        /// Gets the list of <c>ServerElement</c> instances on the specified environment.
        /// </summary>
        /// <param name="environment"><c>EnvironmentElement</c> instance.</param>
        /// <returns>Returns the list of <c>ServerElement</c> instances.</returns>
        public IEnumerable<ServerElement> GetServersOnEnvironment(EnvironmentElement environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            var servers = environment.Servers.AsEnumerable<ServerElement, ServerElementCollection>();
            return servers;
        }

        /// <summary>
        /// Gets the list of <c>EnvironmentElement</c> instances from the configuration settings.
        /// </summary>
        /// <returns>Returns the list of <c>EnvironmentElement</c> instances.</returns>
        public IEnumerable<EnvironmentElement> GetEnvironments()
        {
            var environments = this._settings.Environments.AsEnumerable<EnvironmentElement, EnvironmentElementCollection>();
            return environments;
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