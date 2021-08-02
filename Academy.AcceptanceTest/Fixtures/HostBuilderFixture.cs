using System;
using Academy.AcceptanceTest.Core;
using Academy.AcceptanceTest.NetCoreHosting;

namespace Academy.AcceptanceTest.Fixtures
{
    public class HostBuilderFixture : IDisposable
    {
        private readonly IStartableHost _host = new DotNetCoreHost(new DotNetCoreHostOptions()
        {
            Port = HostConstants.Port,
            CsProjectPath = HostConstants.CsProjectPath
        });

        public HostBuilderFixture()
        {
            _host.Start();
        }

        public void Dispose()
        {
            _host.Stop();
        }
    }
}