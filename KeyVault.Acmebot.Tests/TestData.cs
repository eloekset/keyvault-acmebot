using System.Text;
using System.Xml;

namespace KeyVault.Acmebot.Tests;

internal class TestData
{
    public const string DomeneShopDomainsResponse_sample1 = "DomeneShopDomainsResponse_sample1";
    public const string DomeneShopDnsRecordsResponse_example1_com_sample1 = "DomeneShopDnsRecordsResponse_example1_com_sample1";
    public const string Namecheap_InvalidRequestIP_sample1 = "Namecheap_InvalidRequestIP_sample1";
    public const string NamecheapDomainsResponse_singlepage = "NamecheapDomainsResponse_singlepage";
    public const string NamecheapDomainsResponse_page1of2 = "NamecheapDomainsResponse_page1of2";
    public const string NamecheapDomainsResponse_page2of2 = "NamecheapDomainsResponse_page2of2";
    public const string NamecheapDomainsResponse_page3of2 = "NamecheapDomainsResponse_page3of2";
    public const string NamecheapDomainsResponse_page1of3 = "NamecheapDomainsResponse_page1of3";
    public const string NamecheapDomainsResponse_page2of3 = "NamecheapDomainsResponse_page2of3";
    public const string NamecheapDomainsResponse_page3of3 = "NamecheapDomainsResponse_page3of3";
    public const string NamecheapDomainsResponse_page4of3 = "NamecheapDomainsResponse_page4of3";
    public const string NamecheapGetHostsResponse_example1_com_sample1 = "NamecheapGetHostsResponse_example1_com_sample1";
    public const string NamecheapSetHostsResponse_example1_success = "NamecheapSetHostsResponse_example1_success";
    public const string NamecheapSetHostsResponse_example1_failure = "NamecheapSetHostsResponse_example1_failure";

    public static string ReadResourceAsString(string resourceKey)
    {
        byte[] data = Properties.Resources.ResourceManager.GetObject(resourceKey) as byte[];

        if (data == null)
        {
            return Properties.Resources.ResourceManager.GetString(resourceKey);
        }

        return Encoding.UTF8.GetString(data);
    }

    public static XmlDocument GetResourceAsXmlDocument(string resourceKey)
    {
        XmlDocument xmlDocument = new XmlDocument() { PreserveWhitespace = true };
        string xml = ReadResourceAsString(resourceKey);
        xmlDocument.LoadXml(xml);

        return xmlDocument;
    }
}
