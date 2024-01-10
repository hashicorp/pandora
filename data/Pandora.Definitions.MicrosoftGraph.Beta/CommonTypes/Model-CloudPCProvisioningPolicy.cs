// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCProvisioningPolicyModel
{
    [JsonPropertyName("alternateResourceUrl")]
    public string? AlternateResourceUrl { get; set; }

    [JsonPropertyName("assignments")]
    public List<CloudPCProvisioningPolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("cloudPcGroupDisplayName")]
    public string? CloudPCGroupDisplayName { get; set; }

    [JsonPropertyName("cloudPcNamingTemplate")]
    public string? CloudPCNamingTemplate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("domainJoinConfiguration")]
    public CloudPCDomainJoinConfigurationModel? DomainJoinConfiguration { get; set; }

    [JsonPropertyName("domainJoinConfigurations")]
    public List<CloudPCDomainJoinConfigurationModel>? DomainJoinConfigurations { get; set; }

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
    public CloudPCProvisioningPolicyImageTypeConstant? ImageType { get; set; }

    [JsonPropertyName("localAdminEnabled")]
    public bool? LocalAdminEnabled { get; set; }

    [JsonPropertyName("managedBy")]
    public CloudPCProvisioningPolicyManagedByConstant? ManagedBy { get; set; }

    [JsonPropertyName("microsoftManagedDesktop")]
    public MicrosoftManagedDesktopModel? MicrosoftManagedDesktop { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesConnectionId")]
    public string? OnPremisesConnectionId { get; set; }

    [JsonPropertyName("provisioningType")]
    public CloudPCProvisioningPolicyProvisioningTypeConstant? ProvisioningType { get; set; }

    [JsonPropertyName("scopeIds")]
    public List<string>? ScopeIds { get; set; }

    [JsonPropertyName("windowsSettings")]
    public CloudPCWindowsSettingsModel? WindowsSettings { get; set; }
}
