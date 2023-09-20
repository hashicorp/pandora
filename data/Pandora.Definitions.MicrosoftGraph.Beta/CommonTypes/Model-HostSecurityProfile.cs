// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class HostSecurityProfileModel
{
    [JsonPropertyName("azureSubscriptionId")]
    public string? AzureSubscriptionId { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAzureAdJoined")]
    public bool? IsAzureAdJoined { get; set; }

    [JsonPropertyName("isAzureAdRegistered")]
    public bool? IsAzureAdRegistered { get; set; }

    [JsonPropertyName("isHybridAzureDomainJoined")]
    public bool? IsHybridAzureDomainJoined { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("logonUsers")]
    public List<LogonUserModel>? LogonUsers { get; set; }

    [JsonPropertyName("netBiosName")]
    public string? NetBiosName { get; set; }

    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("os")]
    public string? Os { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("parentHost")]
    public string? ParentHost { get; set; }

    [JsonPropertyName("relatedHostIds")]
    public List<string>? RelatedHostIds { get; set; }

    [JsonPropertyName("riskScore")]
    public string? RiskScore { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("vendorInformation")]
    public SecurityVendorInformationModel? VendorInformation { get; set; }
}
