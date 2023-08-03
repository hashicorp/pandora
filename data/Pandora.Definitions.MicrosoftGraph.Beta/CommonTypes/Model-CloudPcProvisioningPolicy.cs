// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPcProvisioningPolicyModel
{
    [JsonPropertyName("alternateResourceUrl")]
    public string? AlternateResourceUrl { get; set; }

    [JsonPropertyName("assignments")]
    public List<CloudPcProvisioningPolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("cloudPcGroupDisplayName")]
    public string? CloudPcGroupDisplayName { get; set; }

    [JsonPropertyName("cloudPcNamingTemplate")]
    public string? CloudPcNamingTemplate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("domainJoinConfiguration")]
    public CloudPcDomainJoinConfigurationModel? DomainJoinConfiguration { get; set; }

    [JsonPropertyName("domainJoinConfigurations")]
    public List<CloudPcDomainJoinConfigurationModel>? DomainJoinConfigurations { get; set; }

    [JsonPropertyName("enableSingleSignOn")]
    public bool? EnableSingleSignOn { get; set; }

    [JsonPropertyName("gracePeriodInHours")]
    public int? GracePeriodInHours { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("imageDisplayName")]
    public string? ImageDisplayName { get; set; }

    [JsonPropertyName("imageId")]
    public string? ImageId { get; set; }

    [JsonPropertyName("imageType")]
    public CloudPcProvisioningPolicyImageTypeConstant? ImageType { get; set; }

    [JsonPropertyName("localAdminEnabled")]
    public bool? LocalAdminEnabled { get; set; }

    [JsonPropertyName("managedBy")]
    public CloudPcManagementServiceConstant? ManagedBy { get; set; }

    [JsonPropertyName("microsoftManagedDesktop")]
    public MicrosoftManagedDesktopModel? MicrosoftManagedDesktop { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesConnectionId")]
    public string? OnPremisesConnectionId { get; set; }

    [JsonPropertyName("provisioningType")]
    public CloudPcProvisioningTypeConstant? ProvisioningType { get; set; }

    [JsonPropertyName("windowsSettings")]
    public CloudPcWindowsSettingsModel? WindowsSettings { get; set; }
}
