using System.Collections.Generic;
using System.ServiceProcess;

namespace Aliencube.WindowsServicesMonitoring.ViewModels
{
    /// <summary>
    /// This represents the view model entity for monitoring service.
    /// </summary>
    public class MonitoringServiceViewModel
    {
        /// <summary>
        /// Gets or sets the list of environments.
        /// </summary>
        public IEnumerable<EnvironmentViewModel> Environments { get; set; }
    }

    /// <summary>
    /// This represents the view model entity for environment.
    /// </summary>
    public class EnvironmentViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of servers.
        /// </summary>
        public IEnumerable<ServerViewModel> Servers { get; set; }
    }

    /// <summary>
    /// This represents the view model entity for server.
    /// </summary>
    public class ServerViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of services.
        /// </summary>
        public IEnumerable<ServiceViewModel> Services { get; set; }
    }

    /// <summary>
    /// This represents the view model entity for service.
    /// </summary>
    public class ServiceViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <c>ServiceController</c> instance.
        /// </summary>
        public ServiceController Service { get; set; }
    }
}