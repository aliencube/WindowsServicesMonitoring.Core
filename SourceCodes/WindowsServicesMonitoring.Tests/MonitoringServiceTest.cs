using Aliencube.WindowsServicesMonitoring.Services;
using Aliencube.WindowsServicesMonitoring.Services.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Aliencube.WindowsServicesMonitoring.Tests
{
    [TestFixture]
    public class MonitoringServiceTest
    {
        #region SetUp / TearDown

        private IMonitoringSettingsProvider _settings;
        private IMonitoringServiceHelper _helper;
        private IMonitoringService _service;

        [SetUp]
        public void Init()
        {
            this._settings = new MonitoringSettingsProvider();
            this._helper = new MonitoringServiceHelper(this._settings);
            this._service = new MonitoringService(this._helper);
        }

        [TearDown]
        public void Dispose()
        {
            if (this._service != null)
                this._service.Dispose();

            if (this._helper != null)
                this._helper.Dispose();

            if (this._settings != null)
                this._settings.Dispose();
        }

        #endregion SetUp / TearDown

        #region Tests

        [Test]
        [TestCase("DEV", "localhost", "W3SVC")]
        public void GetMonitoringService_GivenSettings_ReturnResult(string envName, string serverName, string serviceName)
        {
            var service = this._service.GetMonitoringService();
            var env = service.Environments.SingleOrDefault(p => p.Name == envName);
            env.Should().NotBeNull();

            var srv = env.Servers.SingleOrDefault(p => p.Name == serverName);
            srv.Should().NotBeNull();

            var svc = srv.Services.SingleOrDefault(p => p.Name == serviceName);
            svc.Should().NotBeNull();
        }

        #endregion Tests
    }
}