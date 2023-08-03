// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IpSecurityProfileModel
{
    [JsonPropertyName("activityGroupNames")]
    public List<string>? ActivityGroupNames { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("azureSubscriptionId")]
    public string? AzureSubscriptionId { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("countHits")]
    public int? CountHits { get; set; }

    [JsonPropertyName("countHosts")]
    public int? CountHosts { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ipCategories")]
    public List<IpCategoryModel>? IpCategories { get; set; }

    [JsonPropertyName("ipReferenceData")]
    public List<IpReferenceDataModel>? IpReferenceData { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("riskScore")]
    public string? RiskScore { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("vendorInformation")]
    public SecurityVendorInformationModel? VendorInformation { get; set; }
}
