﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeyVault.Acmebot.Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KeyVault.Acmebot.Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] DomeneShopDnsRecordsResponse_example1_com_sample1 {
            get {
                object obj = ResourceManager.GetObject("DomeneShopDnsRecordsResponse_example1_com_sample1", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] DomeneShopDomainsResponse_sample1 {
            get {
                object obj = ResourceManager.GetObject("DomeneShopDomainsResponse_sample1", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;ERROR&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors&gt;
        ///    &lt;Error Number=&quot;1011150&quot;&gt;Invalid request IP: 80.90.150.60&lt;/Error&gt;
        ///  &lt;/Errors&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand /&gt;
        ///  &lt;Server&gt;PHX01APIEXT11&lt;/Server&gt;
        ///  &lt;GMTTimeDifference&gt;--4:00&lt;/GMTTimeDifference&gt;
        ///  &lt;ExecutionTime&gt;0&lt;/ExecutionTime&gt;
        ///&lt;/ApiResponse&gt;
        ///.
        /// </summary>
        internal static string Namecheap_InvalidRequestIP_sample1 {
            get {
                return ResourceManager.GetString("Namecheap_InvalidRequestIP_sample1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult&gt;
        ///      &lt;Domain ID=&quot;100&quot; Name=&quot;example1.com&quot; User=&quot;apiuser1&quot; Created=&quot;08/14/2012&quot; Expires=&quot;08/14/2022&quot; IsExpired=&quot;false&quot; IsLocked=&quot;false&quot; AutoRenew=&quot;true&quot; WhoisGuard=&quot;ENABLED&quot; IsPremium=&quot;false&quot; IsOurDNS=&quot;true&quot; /&gt;
        ///      &lt;Dom [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_page1of2 {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_page1of2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult&gt;
        ///      &lt;Domain ID=&quot;100&quot; Name=&quot;example1.com&quot; User=&quot;apiuser1&quot; Created=&quot;08/14/2012&quot; Expires=&quot;08/14/2022&quot; IsExpired=&quot;false&quot; IsLocked=&quot;false&quot; AutoRenew=&quot;true&quot; WhoisGuard=&quot;ENABLED&quot; IsPremium=&quot;false&quot; IsOurDNS=&quot;true&quot; /&gt;
        ///      &lt;Dom [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_page1of3 {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_page1of3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult&gt;
        ///      &lt;Domain ID=&quot;349&quot; Name=&quot;example21.com&quot; User=&quot;apiuser1&quot; Created=&quot;09/21/2018&quot; Expires=&quot;09/21/2022&quot; IsExpired=&quot;false&quot; IsLocked=&quot;false&quot; AutoRenew=&quot;true&quot; WhoisGuard=&quot;ENABLED&quot; IsPremium=&quot;false&quot; IsOurDNS=&quot;true&quot; /&gt;
        ///      &lt;Do [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_page2of2 {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_page2of2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult&gt;
        ///      &lt;Domain ID=&quot;349&quot; Name=&quot;example21.com&quot; User=&quot;apiuser1&quot; Created=&quot;08/14/2012&quot; Expires=&quot;08/14/2022&quot; IsExpired=&quot;false&quot; IsLocked=&quot;false&quot; AutoRenew=&quot;true&quot; WhoisGuard=&quot;ENABLED&quot; IsPremium=&quot;false&quot; IsOurDNS=&quot;true&quot; /&gt;
        ///      &lt;Do [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_page2of3 {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_page2of3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult /&gt;
        ///    &lt;Paging&gt;
        ///      &lt;TotalItems&gt;23&lt;/TotalItems&gt;
        ///      &lt;CurrentPage&gt;3&lt;/CurrentPage&gt;
        ///      &lt;PageSize&gt;20&lt;/PageSize&gt;
        ///    &lt;/Paging&gt;
        ///  &lt;/CommandResponse&gt;
        ///  &lt;Server&gt;PHX01APIEXT11&lt;/Server&gt;
        ///  &lt;GMTTimeDifference&gt;--4:00&lt;/GMTT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_page3of2 {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_page3of2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult&gt;
        ///      &lt;Domain ID=&quot;369&quot; Name=&quot;example41.com&quot; User=&quot;apiuser1&quot; Created=&quot;08/14/2012&quot; Expires=&quot;08/14/2022&quot; IsExpired=&quot;false&quot; IsLocked=&quot;false&quot; AutoRenew=&quot;true&quot; WhoisGuard=&quot;ENABLED&quot; IsPremium=&quot;false&quot; IsOurDNS=&quot;true&quot; /&gt;
        ///      &lt;Do [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_page3of3 {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_page3of3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult /&gt;
        ///    &lt;Paging&gt;
        ///      &lt;TotalItems&gt;43&lt;/TotalItems&gt;
        ///      &lt;CurrentPage&gt;4&lt;/CurrentPage&gt;
        ///      &lt;PageSize&gt;20&lt;/PageSize&gt;
        ///    &lt;/Paging&gt;
        ///  &lt;/CommandResponse&gt;
        ///  &lt;Server&gt;PHX01APIEXT11&lt;/Server&gt;
        ///  &lt;GMTTimeDifference&gt;--4:00&lt;/GMTT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_page4of3 {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_page4of3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.getlist&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.getList&quot;&gt;
        ///    &lt;DomainGetListResult&gt;
        ///      &lt;Domain ID=&quot;100&quot; Name=&quot;example1.com&quot; User=&quot;apiuser1&quot; Created=&quot;08/14/2012&quot; Expires=&quot;08/14/2022&quot; IsExpired=&quot;false&quot; IsLocked=&quot;false&quot; AutoRenew=&quot;true&quot; WhoisGuard=&quot;ENABLED&quot; IsPremium=&quot;false&quot; IsOurDNS=&quot;true&quot; /&gt;
        ///      &lt;Dom [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapDomainsResponse_singlepage {
            get {
                return ResourceManager.GetString("NamecheapDomainsResponse_singlepage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;ApiResponse Status=&quot;OK&quot; xmlns=&quot;http://api.namecheap.com/xml.response&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;Warnings /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.dns.gethosts&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.dns.getHosts&quot;&gt;
        ///    &lt;DomainDNSGetHostsResult Domain=&quot;example1.com&quot; EmailType=&quot;FWD&quot; IsUsingOurDNS=&quot;true&quot;&gt;
        ///      &lt;host HostId=&quot;162122788&quot; Name=&quot;@&quot; Type=&quot;A&quot; Address=&quot;51.120.98.140&quot; MXPref=&quot;10&quot; TTL=&quot;1799&quot; AssociatedAppTitle=&quot;&quot; FriendlyName=&quot;&quot; IsActive=&quot;true&quot; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NamecheapGetHostsResponse_example1_com_sample1 {
            get {
                return ResourceManager.GetString("NamecheapGetHostsResponse_example1_com_sample1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;ApiResponse xmlns=&quot;http://api.namecheap.com/xml.response&quot; Status=&quot;OK&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.dns.setHosts&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.dns.setHosts&quot;&gt;
        ///    &lt;DomainDNSSetHostsResult Domain=&quot;example1.com&quot; IsSuccess=&quot;false&quot; /&gt;
        ///  &lt;/CommandResponse&gt;
        ///  &lt;Server&gt;SERVER-NAME&lt;/Server&gt;
        ///  &lt;GMTTimeDifference&gt;+5&lt;/GMTTimeDifference&gt;
        ///  &lt;ExecutionTime&gt;32.76&lt;/ExecutionTime&gt;
        ///&lt;/ApiResponse&gt;
        ///.
        /// </summary>
        internal static string NamecheapSetHostsResponse_example1_failure {
            get {
                return ResourceManager.GetString("NamecheapSetHostsResponse_example1_failure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;ApiResponse xmlns=&quot;http://api.namecheap.com/xml.response&quot; Status=&quot;OK&quot;&gt;
        ///  &lt;Errors /&gt;
        ///  &lt;RequestedCommand&gt;namecheap.domains.dns.setHosts&lt;/RequestedCommand&gt;
        ///  &lt;CommandResponse Type=&quot;namecheap.domains.dns.setHosts&quot;&gt;
        ///    &lt;DomainDNSSetHostsResult Domain=&quot;example1.com&quot; IsSuccess=&quot;true&quot; /&gt;
        ///  &lt;/CommandResponse&gt;
        ///  &lt;Server&gt;SERVER-NAME&lt;/Server&gt;
        ///  &lt;GMTTimeDifference&gt;+5&lt;/GMTTimeDifference&gt;
        ///  &lt;ExecutionTime&gt;32.76&lt;/ExecutionTime&gt;
        ///&lt;/ApiResponse&gt;
        ///.
        /// </summary>
        internal static string NamecheapSetHostsResponse_example1_success {
            get {
                return ResourceManager.GetString("NamecheapSetHostsResponse_example1_success", resourceCulture);
            }
        }
    }
}
