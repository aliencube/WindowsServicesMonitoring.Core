using Aliencube.WindowsServicesMonitoring.Configurations;
using Aliencube.WindowsServicesMonitoring.Services;
using Aliencube.WindowsServicesMonitoring.Services.Interfaces;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;

namespace Aliencube.WindowsServicesMonitoring.Tests
{
    [TestFixture]
    public class MonitoringServiceHelperTest
    {
        #region SetUp / TearDown

        private IMonitoringSettingsProvider _settings;
        private IMonitoringServiceHelper _helper;

        [SetUp]
        public void Init()
        {
            this._settings = Substitute.For<IMonitoringSettingsProvider>();
            this._helper = new MonitoringServiceHelper(this._settings);
        }

        [TearDown]
        public void Dispose()
        {
            if (this._helper != null)
                this._helper.Dispose();

            if (this._settings != null)
                this._settings.Dispose();
        }

        #endregion SetUp / TearDown

        #region Tests

        [Test]
        [TestCase("DEV", 1)]
        [TestCase("DEV,TEST", 2)]
        public void GetEnvironments_GivenSettings_ReturnResult(string envNames, int expected)
        {
            var environments = new EnvironmentElementCollection();
            var names = envNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                environments.Add(new EnvironmentElement() { Name = name });
            }

            this._settings.Environments.Returns(environments);

            this._helper.GetEnvironments().Count().Should().Be(expected);
        }

        [Test]
        [TestCase("APPSERVER01", 1)]
        [TestCase("APPSERVER01,APPSERVER02", 2)]
        public void GetServersOnEnvironment_GivenSettings_ReturnResult(string serverNames, int expected)
        {
            var environment = new EnvironmentElement() { Name = "DEV", Servers = new ServerElementCollection() };
            var names = serverNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                environment.Servers.Add(new ServerElement() { Name = name });
            }

            this._helper.GetServersOnEnvironment(environment).Count().Should().Be(expected);
        }

        [Test]
        [TestCase("Batch.Service", 1)]
        [TestCase("Batch.Service,Windows.Service", 2)]
        public void GetServicesOnServer_GivenSettings_ReturnResult(string serviceNames, int expected)
        {
            var server = new ServerElement() { Name = "APPSERVER01", Services = new ServiceElementCollection() };
            var names = serviceNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                server.Services.Add(new ServiceElement() { Name = name });
            }

            this._helper.GetServicesOnServer(server).Count().Should().Be(expected);
        }

        [Test]
        [TestCase("W3SVC")]
        public void GetService_GivenSettings_ReturnResult(string serviceName)
        {
            // This assumes that IIS is running on the developer's local box.
            this._helper.GetService("localhost", serviceName).Should().NotBeNull();
        }

        #endregion Tests
    }
}