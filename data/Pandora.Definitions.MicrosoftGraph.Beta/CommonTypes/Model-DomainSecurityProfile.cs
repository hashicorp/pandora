// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DomainSecurityProfileModel
{
    [JsonPropertyName("activityGroupNames")]
    public List<string>? ActivityGroupNames { get; set; }

    [JsonPropertyName("azureSubscriptionId")]
    public string? AzureSubscriptionId { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("countHits")]
    public int? CountHits { get; set; }

    [JsonPropertyName("countInOrg")]
    public int? CountInOrg { get; set; }

    [JsonPropertyName("domainCategories")]
    public List<ReputationCategoryModel>? DomainCategories { get; set; }

    [JsonPropertyName("domainRegisteredDateTime")]
    public DateTime? DomainRegisteredDateTime { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("registrant")]
    public DomainRegistrantModel? Registrant { get; set; }

    [JsonPropertyName("riskScore")]
    public string? RiskScore { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("vendorInformation")]
    public SecurityVendorInformationModel? VendorInformation { get; set; }
}
