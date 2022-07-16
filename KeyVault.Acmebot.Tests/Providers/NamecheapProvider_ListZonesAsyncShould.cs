using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using KeyVault.Acmebot.Providers;

using Moq;
using Moq.Contrib.HttpClient;
using Moq.Protected;

using Shouldly;

using Xunit;

namespace KeyVault.Acmebot.Tests.Providers
{
    public class NamecheapProvider_ListZonesAsyncShould : NamecheapProviderTestBase
    {

        public NamecheapProvider_ListZonesAsyncShould()
            : base()
        { }

        [Fact]
        public async Task ReturnListOfDomains()
        {
            // Arrange
            var responseData = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_singlepage);
            string clientIp = "80.90.150.60";
            string command = "namecheap.domains.getList";
            Uri requestUri = CreateRequestUri(_options.ApiUser, _options.ApiKey, clientIp, command);
            _mockHttpMessageHandler.Protected().As<IHttpMessageHandler>()
                .Setup<Task<HttpResponseMessage>>(x => x.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                    r.Method == HttpMethod.Get &&
                    r.RequestUri == requestUri),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(CreateHttpResponseMessageXmlString(responseData, HttpStatusCode.OK));

            // Act
            var actualDnsZones = await _provider.ListZonesAsync();

            // Assert
            actualDnsZones.ShouldNotBeNull("An object was returned");
            actualDnsZones.Count.ShouldBe(3, "Three domains were returned");
            foreach (var zone in actualDnsZones)
            {
                zone.Id.ShouldNotBeNullOrWhiteSpace("Id has been populated");
                zone.Name.ShouldNotBeNullOrWhiteSpace("Name has been populated");
            }
        }

        [Fact]
        public async Task SupportTwoPagesResponse()
        {
            // Arrange
            var page1of2Reponse = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_page1of2);
            var page2of2Reponse = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_page2of2);
            var page3of2Reponse = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_page3of2);
            string clientIp = "80.90.150.60";
            string command = "namecheap.domains.getList";
            int expectedNumberOfDomains = 23;

            Uri MockResponse(string responseMessage, int? pageParameterForRequestUri = null)
            {
                Uri requestUri = CreateRequestUri(_options.ApiUser, _options.ApiKey, clientIp, command, page: pageParameterForRequestUri);
                _mockHttpMessageHandler.Protected().As<IHttpMessageHandler>()
                    .Setup<Task<HttpResponseMessage>>(x => x.SendAsync(
                        It.Is<HttpRequestMessage>(r =>
                        r.Method == HttpMethod.Get &&
                        r.RequestUri == requestUri),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(CreateHttpResponseMessageXmlString(responseMessage, HttpStatusCode.OK)).Verifiable();

                return requestUri;
            }

            // Page 1 without page parameter, page 2 because response has two pages, page 3 to verify recursive calls end
            var page1RequestUri = MockResponse(page1of2Reponse, pageParameterForRequestUri: null);
            var page2RequestUri = MockResponse(page2of2Reponse, pageParameterForRequestUri: 2);
            var page3RequestUri = MockResponse(page3of2Reponse, pageParameterForRequestUri: 3);

            // Act
            var actualDnsZones = await _provider.ListZonesAsync();

            // Assert
            actualDnsZones.ShouldNotBeNull("An object was returned");
            actualDnsZones.Count.ShouldBe(expectedNumberOfDomains, "23 domains were returned");
            foreach (var zone in actualDnsZones)
            {
                zone.Id.ShouldNotBeNullOrWhiteSpace("Id has been populated");
                zone.Name.ShouldNotBeNullOrWhiteSpace("Name has been populated");
            }

            // Page 2 of 2 should have been requested
            _mockHttpMessageHandler.VerifyRequest(page2RequestUri, Times.Once(), "Provider should have requested a second page of domains");

            // Page 3 of 2 should not have been requested
            _mockHttpMessageHandler.VerifyRequest(page3RequestUri, Times.Never(), "Provider should not have requested a third page of domains");
        }

        [Fact]
        public async Task SupportMoreThanTwoPagesResponse()
        {
            // Arrange
            var page1of3Reponse = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_page1of3);
            var page2of3Reponse = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_page2of3);
            var page3of3Reponse = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_page3of3);
            var page4of3Reponse = TestData.ReadResourceAsString(TestData.NamecheapDomainsResponse_page4of3);
            string clientIp = "80.90.150.60";
            string command = "namecheap.domains.getList";
            int expectedNumberOfDomains = 43;

            Uri MockResponse(string responseMessage, int? pageParameterForRequestUri = null)
            {
                Uri requestUri = CreateRequestUri(_options.ApiUser, _options.ApiKey, clientIp, command, page: pageParameterForRequestUri);
                _mockHttpMessageHandler.Protected().As<IHttpMessageHandler>()
                    .Setup<Task<HttpResponseMessage>>(x => x.SendAsync(
                        It.Is<HttpRequestMessage>(r =>
                        r.Method == HttpMethod.Get &&
                        r.RequestUri == requestUri),
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(CreateHttpResponseMessageXmlString(responseMessage, HttpStatusCode.OK)).Verifiable();

                return requestUri;
            }

            // Page 1 without page parameter, pages 2 and 3 because response has three pages, page 4 to verify recursive calls end
            var page1RequestUri = MockResponse(page1of3Reponse, pageParameterForRequestUri: null);
            var page2RequestUri = MockResponse(page2of3Reponse, pageParameterForRequestUri: 2);
            var page3RequestUri = MockResponse(page3of3Reponse, pageParameterForRequestUri: 3);
            var page4RequestUri = MockResponse(page4of3Reponse, pageParameterForRequestUri: 4);

            // Act
            var actualDnsZones = await _provider.ListZonesAsync();

            // Assert
            actualDnsZones.ShouldNotBeNull("An object was returned");
            actualDnsZones.Count.ShouldBe(expectedNumberOfDomains, "23 domains were returned");
            foreach (var zone in actualDnsZones)
            {
                zone.Id.ShouldNotBeNullOrWhiteSpace("Id has been populated");
                zone.Name.ShouldNotBeNullOrWhiteSpace("Name has been populated");
            }

            // Page 2 of 3 should have been requested
            _mockHttpMessageHandler.VerifyRequest(page2RequestUri, Times.Once(), "Provider should have requested a second page of domains");

            // Page 3 of 3 should have been requested
            _mockHttpMessageHandler.VerifyRequest(page3RequestUri, Times.Once(), "Provider should have requested a third page of domains");

            // Page 4 of 3 should not have been requested
            _mockHttpMessageHandler.VerifyRequest(page4RequestUri, Times.Never(), "Provider should not have requested a fourth page of domains");
        }

        [Fact]
        public async Task ThrowOnInvalidClientIpAddress()
        {
            // Arrange
            string errorResponse = TestData.ReadResourceAsString(TestData.Namecheap_InvalidRequestIP_sample1);
            string clientIp = "80.90.150.60";
            string command = "namecheap.domains.getList";
            Uri requestUri = CreateRequestUri(_options.ApiUser, _options.ApiKey, clientIp, command);
            _mockHttpMessageHandler.Protected().As<IHttpMessageHandler>()
                .Setup<Task<HttpResponseMessage>>(x => x.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                    r.Method == HttpMethod.Get &&
                    r.RequestUri == requestUri),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(CreateHttpResponseMessageXmlString(errorResponse, HttpStatusCode.OK));
            Exception actualException = null;
            IEnumerable<DnsZone> actualDnsZones = null;

            // Act
            try
            {
                actualDnsZones = await _provider.ListZonesAsync();
            }
            catch(Exception ex)
            {
                actualException = ex;
            }

            // Assert
            actualException.ShouldNotBeNull("An exception was thrown");
            actualException.Message.ShouldStartWith("IP address 80.90.150.60 must be whitelisted at your Namecheap account");
        }

    }
}
