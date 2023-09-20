// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudAppSecurityProfileModel
{
    [JsonPropertyName("azureSubscriptionId")]
    public string? AzureSubscriptionId { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deploymentPackageUrl")]
    public string? DeploymentPackageUrl { get; set; }

    [JsonPropertyName("destinationServiceName")]
    public string? DestinationServiceName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isSigned")]
    public bool? IsSigned { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("manifest")]
    public string? Manifest { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissionsRequired")]
    public CloudAppSecurityProfilePermissionsRequiredConstant? PermissionsRequired { get; set; }

    [JsonPropertyName("platform")]
    public string? Platform { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("riskScore")]
    public string? RiskScore { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("vendorInformation")]
    public SecurityVendorInformationModel? VendorInformation { get; set; }
}
