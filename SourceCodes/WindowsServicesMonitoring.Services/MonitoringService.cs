using Aliencube.WindowsServicesMonitoring.Services.Interfaces;
using Aliencube.WindowsServicesMonitoring.ViewModels;
using System;
using System.Linq;

namespace Aliencube.WindowsServicesMonitoring.Services
{
    /// <summary>
    /// This represents the monitoring servic entity.
    /// </summary>
    public class MonitoringService : IMonitoringService
    {
        private readonly IMonitoringServiceHelper _helper;

        /// <summary>
        /// Initialises a new instance of the MonitoringService class.
        /// </summary>
        /// <param name="helper"><c>MonitoringServiceHelper</c> instance.</param>
        public MonitoringService(IMonitoringServiceHelper helper)
        {
            if (helper == null)
            {
                throw new ArgumentNullException("helper");
            }
            this._helper = helper;
        }

        /// <summary>
        /// Gets the <c>MonitoringServiceViewModel</c> instance.
        /// </summary>
        /// <returns>Returns the <c>MonitoringServiceViewModel</c> instance.</returns>
        public MonitoringServiceViewModel GetMonitoringService()
        {
            var vm = new MonitoringServiceViewModel()
                     {
                         Environments = this._helper
                                            .GetEnvironments()
                                            .Select(env => new EnvironmentViewModel()
                                                           {
                                                               Name = env.Name,
                                                               Servers = this._helper
                                                                             .GetServersOnEnvironment(env)
                                                                             .Select(srv => new ServerViewModel()
                                                                                            {
                                                                                                Name = srv.Name,
                                                                                                Services = this._helper
                                                                                                               .GetServicesOnServer(srv)
                                                                                                               .Select(svc => this._helper.GetService(srv.Name, svc.Name))
                                                                                            })
                                                           })
                     };
            return vm;
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