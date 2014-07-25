# WindowsServicesMonitoring.Core #

**WindowsServicesMonitoring.Core** provides the core logic for `WindowsServicesMonitoring.X`.


# Contribution #

Your contribution is always welcome! All your work should be done in the`dev` branch. Once you finish your work, please send us a pull request on `dev` for review. Make sure that all your changes **MUST** be covered with test codes; otherwise yours won't get accepted.


## Configuration ##

In order to configure the `WindowsServicesMonitoringService` instance, either `App.config` or `Web.config` should be updated with the following settings.

```xml
<configSections>
    <section name="monitoringSettings" type="Aliencube.WindowsServicesMonitoring.Configurations.MonitoringSettingsSection, Aliencube.WindowsServicesMonitoring.Configurations" requirePermission="false" />
</configSections>

<monitoringSettings>
    <environments>
        <environment name="DEV">
            <servers>
                <server name="localhost">
                    <services>
                        <service name="W3SVC" expected="running" username="username" password="password" />
                    </services>
                </server>
            </servers>
        </environment>
    </environments>
</monitoringSettings>
```

* `<environments>`: Collection of the `<environment>` element.
* `<environment>`: This defines environment that contains collection of servers.
  *  `name`: It is a unique name for each environment. This can be `DEV`, `TEST`, `STAGING` or `PRODUCTION`.
* `<servers>`: Collection of the `<server>` element.
* `<server>`: This defines the actual server that runs Windows Services.
  * `name`: Name of the server, that is identifiable within the network. Make sure that this is not a domain name or URL. Possible name can be `APPSERVER01`, `WEBSERVER01` or `SQLSERVER01`.
* `<services>`: Collection of the `<service>` element.
* `<service>`: This defines the actual Windows Service to monitor.
  * `name`: Service Name of Windows Service, which is different from Display Name. For example, IIS has its display name of `World Wide Web Publishing Service` while its service name of `W3SVC`.
  * `expected`: Enum value of the service status. This value MUST be one of the following: `Stopped`,` StartPending`, `StopPending`, `Running`, `ContinuePending`, `PausePending`, `Paused`. Usually `Stopped` or `Running` can be enough.
  * `username`: Windows Account to execute the service.
  * `password`: Password of the Windows Account to execute the service.       


## License ##

**WindowsServicesMonitoring.Core** is released under [MIT License](http://opensource.org/licenses/MIT).

> The MIT License (MIT)
> 
> Copyright (c) 2014 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
