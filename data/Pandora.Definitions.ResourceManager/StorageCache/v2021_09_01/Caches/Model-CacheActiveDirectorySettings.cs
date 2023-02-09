using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;


internal class CacheActiveDirectorySettingsModel
{
    [JsonPropertyName("cacheNetBiosName")]
    [Required]
    public string CacheNetBiosName { get; set; }

    [JsonPropertyName("credentials")]
    public CacheActiveDirectorySettingsCredentialsModel? Credentials { get; set; }

    [JsonPropertyName("domainJoined")]
    public DomainJoinedTypeConstant? DomainJoined { get; set; }

    [JsonPropertyName("domainName")]
    [Required]
    public string DomainName { get; set; }

    [JsonPropertyName("domainNetBiosName")]
    [Required]
    public string DomainNetBiosName { get; set; }

    [JsonPropertyName("primaryDnsIpAddress")]
    [Required]
    public string PrimaryDnsIPAddress { get; set; }

    [JsonPropertyName("secondaryDnsIpAddress")]
    public string? SecondaryDnsIPAddress { get; set; }
}
