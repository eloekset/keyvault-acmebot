
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

using Shouldly;

using Xunit;

namespace KeyVault.Acmebot.Tests.Providers;

public class NamecheapProvider_DeleteTxtRecordAsyncShould : NamecheapProviderGetAndSetHostsTestBase
{
    public NamecheapProvider_DeleteTxtRecordAsyncShould()
        : base()
    { }

    [Fact]
    public async Task CallSetHosts_WithAllExistingRecords_ExceptTheOneToBeDeleted()
    {
        // Arrange
        string expectedTxtRecordToBeDeleted = "_acme-challenge.www";
        var getHostsResponseData = TestData.ReadResourceAsString(TestData.NamecheapGetHostsResponse_example1_com_sample1);
        Uri expectedGetHostsRequestUri = ArrangeDefaultGetHostsCall_ReturnExpectedRequestUri(
                getHostsResponseData,
                DefaultDomainSLD,
                DefaultDomainTLD
            );
        var setHostsResponseData = TestData.ReadResourceAsString(TestData.NamecheapSetHostsResponse_example1_success);

        // Build the expected setHosts URI to be called
        var setHostsUriBuilder = new SetHostsUriBuilder();
        var hostsExceptTheOneToDelete = setHostsUriBuilder.Sample1Hosts.Values.Where(h => h.HostName != expectedTxtRecordToBeDeleted);
        int originalHostCount = setHostsUriBuilder.Sample1Hosts.Count;
        setHostsUriBuilder.AppendHostPart(hostsExceptTheOneToDelete);

        // Make sure we've deleted exactly one host before building the request URI to verify
        hostsExceptTheOneToDelete.Count().ShouldBe(setHostsUriBuilder.Sample1Hosts.Count - 1, "One host is removed");

        // Arrange the GET reqeust to be verified
        Uri expectedSetHostsRequestUri = ArrangeDefaultSetHostsCall_ReturnExpectedRequestUri(
                expectedSetHostsUriPart: setHostsUriBuilder.BuildUri(),
                domainSLD: DefaultDomainSLD,
                domainTLD: DefaultDomainTLD,
                emailType: "FWD",
                expectedSetHostsResponseData: setHostsResponseData
            );
        DnsZone expectedDnsZone = new DnsZone(_provider)
        {
            Id = "123",
            Name = $"{DefaultDomainSLD}.{DefaultDomainTLD}"
        };
        Exception actualException = null;

        // Act
        try
        {
            await _provider.DeleteTxtRecordAsync(expectedDnsZone, expectedTxtRecordToBeDeleted);
        }
        catch (Exception ex)
        {
            actualException = ex;
        }

        // Assert
        actualException.ShouldBeNull("No exception was thrown");
        _mockHttpMessageHandler.VerifyRequest(expectedGetHostsRequestUri, Times.Once(), "getHosts command with expected URI was called");
        _mockHttpMessageHandler.VerifyRequest(expectedSetHostsRequestUri, Times.Once(), "setHosts command with expected URI was called");
    }

    [Fact]
    public async Task NotCallSetHosts_WhenRecordToBeDeleted_DoesntExist()
    {
        // Arrange
        string nonexistingTxtRecord = "_achme-challenge.newone";
        var getHostsResponseData = TestData.ReadResourceAsString(TestData.NamecheapGetHostsResponse_example1_com_sample1);
        Uri expectedGetHostsRequestUri = ArrangeDefaultGetHostsCall_ReturnExpectedRequestUri(
                getHostsResponseData,
                DefaultDomainSLD,
                DefaultDomainTLD
            );
        var setHostsResponseData = TestData.ReadResourceAsString(TestData.NamecheapSetHostsResponse_example1_success);

        // Build the expected setHosts URI to be called
        var setHostsUriBuilder = new SetHostsUriBuilder();
        setHostsUriBuilder.AppendHostPart(setHostsUriBuilder.Sample1Hosts.Values);

        // Arrange the GET reqeust to be verified
        Uri expectedSetHostsRequestUri = ArrangeDefaultSetHostsCall_ReturnExpectedRequestUri(
                expectedSetHostsUriPart: setHostsUriBuilder.BuildUri(),
                domainSLD: DefaultDomainSLD,
                domainTLD: DefaultDomainTLD,
                emailType: "FWD",
                expectedSetHostsResponseData: setHostsResponseData
            );
        DnsZone expectedDnsZone = new DnsZone(_provider)
        {
            Id = "123",
            Name = $"{DefaultDomainSLD}.{DefaultDomainTLD}"
        };
        Exception actualException = null;

        // Act
        try
        {
            await _provider.DeleteTxtRecordAsync(expectedDnsZone, nonexistingTxtRecord);
        }
        catch (Exception ex)
        {
            actualException = ex;
        }

        // Assert
        actualException.ShouldBeNull("No exception was thrown");
        _mockHttpMessageHandler.VerifyRequest(expectedGetHostsRequestUri, Times.Once(), "getHosts command with expected URI was called");
        _mockHttpMessageHandler.VerifyRequest(expectedSetHostsRequestUri, Times.Never(), "setHosts command with expected URI was not called");
    }

}
