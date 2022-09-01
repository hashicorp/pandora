using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2020_01_01.DomainServices;


internal class DomainServicePropertiesModel
{
    [JsonPropertyName("deploymentId")]
    public string? DeploymentId { get; set; }

    [JsonPropertyName("domainConfigurationType")]
    public string? DomainConfigurationType { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("domainSecuritySettings")]
    public DomainSecuritySettingsModel? DomainSecuritySettings { get; set; }

    [JsonPropertyName("filteredSync")]
    public FilteredSyncConstant? FilteredSync { get; set; }

    [JsonPropertyName("ldapsSettings")]
    public LdapsSettingsModel? LdapsSettings { get; set; }

    [JsonPropertyName("migrationProperties")]
    public MigrationPropertiesModel? MigrationProperties { get; set; }

    [JsonPropertyName("notificationSettings")]
    public NotificationSettingsModel? NotificationSettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("replicaSets")]
    public List<ReplicaSetModel>? ReplicaSets { get; set; }

    [JsonPropertyName("resourceForestSettings")]
    public ResourceForestSettingsModel? ResourceForestSettings { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("syncOwner")]
    public string? SyncOwner { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
