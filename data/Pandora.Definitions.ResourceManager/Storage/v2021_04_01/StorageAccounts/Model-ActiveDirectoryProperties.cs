using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class ActiveDirectoryPropertiesModel
{
    [JsonPropertyName("azureStorageSid")]
    [Required]
    public string AzureStorageSid { get; set; }

    [JsonPropertyName("domainGuid")]
    [Required]
    public string DomainGuid { get; set; }

    [JsonPropertyName("domainName")]
    [Required]
    public string DomainName { get; set; }

    [JsonPropertyName("domainSid")]
    [Required]
    public string DomainSid { get; set; }

    [JsonPropertyName("forestName")]
    [Required]
    public string ForestName { get; set; }

    [JsonPropertyName("netBiosDomainName")]
    [Required]
    public string NetBiosDomainName { get; set; }
}
