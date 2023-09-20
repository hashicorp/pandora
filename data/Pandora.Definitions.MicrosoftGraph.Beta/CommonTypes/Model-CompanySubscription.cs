// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CompanySubscriptionModel
{
    [JsonPropertyName("commerceSubscriptionId")]
    public string? CommerceSubscriptionId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isTrial")]
    public bool? IsTrial { get; set; }

    [JsonPropertyName("nextLifecycleDateTime")]
    public DateTime? NextLifecycleDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ocpSubscriptionId")]
    public string? OcpSubscriptionId { get; set; }

    [JsonPropertyName("ownerId")]
    public string? OwnerId { get; set; }

    [JsonPropertyName("ownerTenantId")]
    public string? OwnerTenantId { get; set; }

    [JsonPropertyName("ownerType")]
    public string? OwnerType { get; set; }

    [JsonPropertyName("serviceStatus")]
    public List<ServicePlanInfoModel>? ServiceStatus { get; set; }

    [JsonPropertyName("skuId")]
    public string? SkuId { get; set; }

    [JsonPropertyName("skuPartNumber")]
    public string? SkuPartNumber { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("totalLicenses")]
    public int? TotalLicenses { get; set; }
}
