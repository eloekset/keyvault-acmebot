
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using KeyVault.Acmebot.Providers;

using Moq;
using Moq.Contrib.HttpClient;
using Moq.Protected;

namespace KeyVault.Acmebot.Tests.Providers
{
    public class NamecheapProviderGetAndSetHostsTestBase : NamecheapProviderTestBase
    {
        public const string ClientIp = "80.90.150.60";
        public const string DefaultDomainSLD = "example1";
        public const string DefaultDomainTLD = "com";

        public NamecheapProviderGetAndSetHostsTestBase()
            : base()
        { }

        protected Uri ArrangeDefaultGetHostsCall_ReturnExpectedRequestUri(string getHostsResponseData, string domainSLD, string domainTLD)
        {
            // Arrange getHosts
            string getHostsCommand = "namecheap.domains.dns.getHosts";
            Uri getHostsRequestUri = CreateRequestUri(
                    apiUser: _options.ApiUser,
                    apiKey: _options.ApiKey,
                    clientIp: ClientIp,
                    command: getHostsCommand,
                    domainSLD: domainSLD,
                    domainTLD: domainTLD
                );
            _mockHttpMessageHandler.Protected().As<IHttpMessageHandler>()
                .Setup<Task<HttpResponseMessage>>(x => x.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                    r.Method == HttpMethod.Get &&
                    r.RequestUri == getHostsRequestUri),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(CreateHttpResponseMessageXmlString(getHostsResponseData, HttpStatusCode.OK)).Verifiable();

            return getHostsRequestUri;
        }

        protected Uri ArrangeDefaultSetHostsCall_ReturnExpectedRequestUri(string expectedSetHostsUriPart, string domainSLD, string domainTLD, string emailType, string expectedSetHostsResponseData)
        {
            string setHostsCommand = "namecheap.domains.dns.setHosts";
            string setHostsRequestUriFirstPart = CreateRequestUri(
                    apiUser: _options.ApiUser,
                    apiKey: _options.ApiKey,
                    clientIp: ClientIp,
                    command: setHostsCommand,
                    domainSLD: domainSLD,
                    domainTLD: domainTLD,
                    emailType: emailType
                ).ToString();
            Uri setHostsRequestUri = new Uri(setHostsRequestUriFirstPart + expectedSetHostsUriPart);
            _mockHttpMessageHandler.Protected().As<IHttpMessageHandler>()
                .Setup<Task<HttpResponseMessage>>(x => x.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                    r.Method == HttpMethod.Get &&
                    r.RequestUri == setHostsRequestUri),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(CreateHttpResponseMessageXmlString(expectedSetHostsResponseData, HttpStatusCode.OK)).Verifiable();

            return setHostsRequestUri;
        }

        protected Uri CreateRequestUri(string apiUser, string apiKey, string clientIp, string command, string domainSLD, string domainTLD, string emailType = null)
        {
            string requestUri = CreateRequestUri(apiUser, apiKey, clientIp, command).ToString();
            requestUri += "&SLD=" + domainSLD;
            requestUri += "&TLD=" + domainTLD;

            if (!string.IsNullOrEmpty(emailType))
            {
                requestUri += "&EmailType=" + emailType;
            }

            return new Uri(requestUri);
        }

        public class SetHostsUriBuilder
        {
            public const string HostName = "HostName";
            public const string RecordType = "RecordType";
            public const string Address = "Address";
            public const string MXPref = "MXPref";
            public const string TTL = "TTL";
            public IDictionary<string, Host> Sample1Hosts = new Dictionary<string, Host>()
            {
                { "162122788", new Host("@", "A", "51.120.98.140") },
                { "176237257", new Host("proxmox", "A", "80.90.150.60") },
                { "269335026", new Host("rdp", "A", "80.90.150.60") },
                { "211238183", new Host("prometheus.srv-1", "AAAA", "2001:4646:6035:0:b883:a458:34c8:1218") },
                { "203542921", new Host("@", "CNAME", "example1.azurewebsites.net.") },
                { "204325083", new Host("test", "CNAME", "test-example1.azurewebsites.net.") },
                { "210458003", new Host("dashboard", "CNAME", "superduperdashboard.azurewebsites.net.") },
                { "205321347", new Host("teststatic", "CNAME", "calm-hill-0d24b1a03.azurestaticapps.net.") },
                { "434453967", new Host("www", "CNAME", "example1.azurewebsites.net.") },
                { "156656991", new Host("@", "TXT", "example1.azurewebsites.net.") },
                { "217662467", new Host("_acme-challenge.test", "TXT", "ZGU1YmE5MDgtZmM3My00ZjZlLTk4OTItMTkxMjhjOWY5ZTg4") },
                { "217232496", new Host("_acme-challenge.dashboard", "TXT", "YzU1MDhjMTYtMzY2Ny00NWMyLWFlOWMtNDQ5ODI0NGYyZWQw") },
                { "217242524", new Host("_acme-challenge.www", "TXT", "NDRmYzM4NDctNWNlOS00MDcwLWFmNzktYTdlYTU5NWY3ZDY4") },
                { "208343834", new Host("_github-challenge-test-example-com.test", "TXT", "b512cb1ce5") },
                { "434434966", new Host("@", "URL", @"https://www.example1.com") }
            };

            private int index = 0;
            private StringBuilder uri = new StringBuilder();

            public SetHostsUriBuilder()
            {
            }

            public void AppendHostPart(IEnumerable<Host> hosts)
            {
                foreach (Host host in hosts)
                {
                    AppendHostPart(host);
                }
            }

            public void AppendHostPart(Host host)
            {
                index++;
                string name = host.HostName;
                string type = host.RecordType;
                string address = host.Address;
                uri.Append($"&{HostName}{index}={name}&{RecordType}{index}={type}&{Address}{index}={address}&{MXPref}{index}=10&{TTL}{index}=1799");
            }

            public string BuildUri()
            {
                return uri.ToString();
            }
        }

        public class Host
        {
            public string HostName { get; set; }
            public string RecordType { get; set; }
            public string Address { get; set; }

            public Host(string hostName, string recordType, string address)
            {
                HostName = hostName;
                RecordType = recordType;
                Address = address;
            }
        }
    }
}
