namespace KeyVault.Acmebot.Tests.Providers;
internal class NamecheapConstants
{
    public const string BaseUri = @"https://api.namecheap.com/xml.response";
    public const string ApiUser1 = @"apiuser1";
    public const string ApiKey1 = @"bb6ee7da1f9043f08b2f214343884d1c";
    public const string ClientIp1 = @"80.90.150.60";
    public const string ApiUserTemplate = @"{apiUser}";
    public const string ApiKeyTemplate = @"{apiKey}";
    public const string ClientIdTemplate = @"{clientId}";
    public const string CommandTemplate = @"{command}";
    public const string AllCommandsTemplate = $"?ApiUser={ApiUserTemplate}&ApiKey={ApiKeyTemplate}&UserName={ApiUserTemplate}&ClientIp={ClientIdTemplate}&Command={CommandTemplate}";
    public const string IpfyOrgUri = @"https://api.ipify.org?format=json";
}
