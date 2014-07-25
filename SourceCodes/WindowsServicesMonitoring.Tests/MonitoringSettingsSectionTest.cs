using Aliencube.WindowsServicesMonitoring.Configurations;
using Aliencube.WindowsServicesMonitoring.Services;
using Aliencube.WindowsServicesMonitoring.Services.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using System.ServiceProcess;

namespace Aliencube.WindowsServicesMonitoring.Tests
{
    [TestFixture]
    public class MonitoringSettingsSectionTest
    {
        #region SetUp / TearDown

        private IMonitoringSettingsProvider _settings;

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Dispose()
        {
            if (this._settings != null)
                this._settings.Dispose();
        }

        #endregion SetUp / TearDown

        #region Tests

        [Test]
        [TestCase("DEV", "localhost", "W3SVC", ServiceControllerStatus.Running, "username", "password")]
        [TestCase("TEST", "TESTAPPSERVER01", "Batch.Service", ServiceControllerStatus.Stopped, "username", "password")]
        [TestCase("TEST", "TESTAPPSERVER01", "Windows.Service", ServiceControllerStatus.Running, "username", "password")]
        public void GetValues_GivenConfig_ReturnResults(string envName, string serverName, string serviceName, ServiceControllerStatus serviceStatus, string username, string password)
        {
            this._settings = new MonitoringSettingsProvider();

            var environments = this._settings.Environments;
            environments.Count.Should().BeGreaterOrEqualTo(1);

            var environment = environments.Cast<EnvironmentElement>()
                                          .SingleOrDefault(env => String.Equals(env.Name, envName,
                                                                                StringComparison.InvariantCultureIgnoreCase));
            environment.Should().NotBeNull();

            var servers = environment.Servers;
            servers.Count.Should().BeGreaterOrEqualTo(1);

            var server = servers.Cast<ServerElement>()
                                .SingleOrDefault(srv => String.Equals(srv.Name, serverName,
                                                                      StringComparison.InvariantCultureIgnoreCase));
            server.Should().NotBeNull();

            var services = server.Services;
            services.Count.Should().BeGreaterOrEqualTo(1);

            var service = services.Cast<ServiceElement>()
                                  .SingleOrDefault(svc => String.Equals(svc.Name, serviceName,
                                                                        StringComparison.InvariantCultureIgnoreCase));
            service.Should().NotBeNull();
            service.Expected.Should().Be(serviceStatus);
            service.Username.Should().Be(username);
            service.Password.Should().Be(password);
        }

        #endregion Tests
    }
}