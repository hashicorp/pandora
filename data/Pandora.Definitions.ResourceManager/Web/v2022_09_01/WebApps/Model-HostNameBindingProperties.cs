using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class HostNameBindingPropertiesModel
{
    [JsonPropertyName("azureResourceName")]
    public string? AzureResourceName { get; set; }

    [JsonPropertyName("azureResourceType")]
    public AzureResourceTypeConstant? AzureResourceType { get; set; }

    [JsonPropertyName("customHostNameDnsRecordType")]
    public CustomHostNameDnsRecordTypeConstant? CustomHostNameDnsRecordType { get; set; }

    [JsonPropertyName("domainId")]
    public string? DomainId { get; set; }

    [JsonPropertyName("hostNameType")]
    public HostNameTypeConstant? HostNameType { get; set; }

    [JsonPropertyName("siteName")]
    public string? SiteName { get; set; }

    [JsonPropertyName("sslState")]
    public SslStateConstant? SslState { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("virtualIP")]
    public string? VirtualIP { get; set; }
}
