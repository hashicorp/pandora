using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.ManagedHsms;


internal class ManagedHsmPropertiesModel
{
    [JsonPropertyName("createMode")]
    public CreateModeConstant? CreateMode { get; set; }

    [JsonPropertyName("enablePurgeProtection")]
    public bool? EnablePurgeProtection { get; set; }

    [JsonPropertyName("enableSoftDelete")]
    public bool? EnableSoftDelete { get; set; }

    [JsonPropertyName("hsmUri")]
    public string? HsmUri { get; set; }

    [JsonPropertyName("initialAdminObjectIds")]
    public List<string>? InitialAdminObjectIds { get; set; }

    [JsonPropertyName("networkAcls")]
    public MHSMNetworkRuleSetModel? NetworkAcls { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<MHSMPrivateEndpointConnectionItemModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("scheduledPurgeDate")]
    public DateTime? ScheduledPurgeDate { get; set; }

    [JsonPropertyName("securityDomainProperties")]
    public ManagedHSMSecurityDomainPropertiesModel? SecurityDomainProperties { get; set; }

    [JsonPropertyName("softDeleteRetentionInDays")]
    public int? SoftDeleteRetentionInDays { get; set; }

    [JsonPropertyName("statusMessage")]
    public string? StatusMessage { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
