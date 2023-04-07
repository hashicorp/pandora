using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Clusters;


internal class SecurityProfileModel
{
    [JsonPropertyName("aaddsResourceId")]
    public string? AaddsResourceId { get; set; }

    [JsonPropertyName("clusterUsersGroupDNs")]
    public List<string>? ClusterUsersGroupDNs { get; set; }

    [JsonPropertyName("directoryType")]
    public DirectoryTypeConstant? DirectoryType { get; set; }

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("domainUserPassword")]
    public string? DomainUserPassword { get; set; }

    [JsonPropertyName("domainUsername")]
    public string? DomainUsername { get; set; }

    [JsonPropertyName("ldapsUrls")]
    public List<string>? LdapsUrls { get; set; }

    [JsonPropertyName("msiResourceId")]
    public string? MsiResourceId { get; set; }

    [JsonPropertyName("organizationalUnitDN")]
    public string? OrganizationalUnitDN { get; set; }
}
