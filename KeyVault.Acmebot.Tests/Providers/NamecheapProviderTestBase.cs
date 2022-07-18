using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

using KeyVault.Acmebot.Options;
using KeyVault.Acmebot.Providers;

using Moq;
using Moq.Contrib.HttpClient;
using Moq.Protected;

namespace KeyVault.Acmebot.Tests.Providers;
public class NamecheapProviderTestBase
{
    protected readonly NamecheapOptions _options;
    protected readonly NamecheapProvider _provider;
    protected readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
    protected readonly Mock<HttpMessageHandler> _mockIpfyOrgHttpMessageHandler;

    public NamecheapProviderTestBase()
    {
        _options = new NamecheapOptions
        {
            ApiUser = NamecheapConstants.ApiUser1,
            ApiKey = NamecheapConstants.ApiKey1
        };
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_mockHttpMessageHandler.Object);
        _mockIpfyOrgHttpMessageHandler = new Mock<HttpMessageHandler>();
        MockNormalIpfyOrgResponse();
        var ipfyOrgHttpClient = new HttpClient(_mockIpfyOrgHttpMessageHandler.Object);
        _provider = new NamecheapProvider(_options, httpClient, ipfyOrgHttpClient);
    }

    protected Uri CreateRequestUri(string apiUser, string apiKey, string clientIp, string command, int? page = null)
    {
        string queryString = NamecheapConstants.AllCommandsTemplate
            .Replace(NamecheapConstants.ApiUserTemplate, apiUser)
            .Replace(NamecheapConstants.ApiKeyTemplate, apiKey)
            .Replace(NamecheapConstants.ClientIdTemplate, clientIp)
            .Replace(NamecheapConstants.CommandTemplate, command);

        if (page != null)
        {
            queryString += $"&Page={page}";
        }

        return new Uri(new Uri(NamecheapConstants.BaseUri), queryString);
    }

    protected void MockNormalIpfyOrgResponse(string ipAddress = NamecheapConstants.ClientIp1)
    {
        _mockIpfyOrgHttpMessageHandler.Protected().As<IHttpMessageHandler>()
            .Setup(x => x.SendAsync(
                It.IsAny<HttpRequestMessage>(),
                It.IsAny<CancellationToken>()
                )
            ).ReturnsAsync(CreateHttpResponseMessageJsonString(CreateIpfyOrgJsonResponse(ipAddress)));
    }

    protected string CreateIpfyOrgJsonResponse(string ipAddress)
    {
        return
@"{
    ""ip"": """ + ipAddress + @"""
}";
    }

    protected HttpResponseMessage CreateHttpResponseMessageJsonString(string responseString, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        var response = new HttpResponseMessage(httpStatusCode);
        response.Content = new StringContent(responseString, Encoding.UTF8, "application/json");

        return response;
    }

    protected HttpResponseMessage CreateHttpResponseMessageXmlString(string responseString, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        var response = new HttpResponseMessage(httpStatusCode);
        response.Content = new StringContent(responseString, Encoding.UTF8, "application/xml");

        return response;
    }
}
