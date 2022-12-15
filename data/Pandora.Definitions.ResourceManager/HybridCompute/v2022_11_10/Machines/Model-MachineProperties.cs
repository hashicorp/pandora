using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_11_10.Machines;


internal class MachinePropertiesModel
{
    [JsonPropertyName("adFqdn")]
    public string? AdFqdn { get; set; }

    [JsonPropertyName("agentConfiguration")]
    public AgentConfigurationModel? AgentConfiguration { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("clientPublicKey")]
    public string? ClientPublicKey { get; set; }

    [JsonPropertyName("cloudMetadata")]
    public CloudMetadataModel? CloudMetadata { get; set; }

    [JsonPropertyName("detectedProperties")]
    public Dictionary<string, string>? DetectedProperties { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dnsFqdn")]
    public string? DnsFqdn { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<ErrorDetailModel>? ErrorDetails { get; set; }

    [JsonPropertyName("extensions")]
    public List<MachineExtensionInstanceViewModel>? Extensions { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStatusChange")]
    public DateTime? LastStatusChange { get; set; }

    [JsonPropertyName("locationData")]
    public LocationDataModel? LocationData { get; set; }

    [JsonPropertyName("machineFqdn")]
    public string? MachineFqdn { get; set; }

    [JsonPropertyName("mssqlDiscovered")]
    public string? MssqlDiscovered { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("osProfile")]
    public OSProfileModel? OsProfile { get; set; }

    [JsonPropertyName("osSku")]
    public string? OsSku { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("parentClusterResourceId")]
    public string? ParentClusterResourceId { get; set; }

    [JsonPropertyName("privateLinkScopeResourceId")]
    public string? PrivateLinkScopeResourceId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("serviceStatuses")]
    public ServiceStatusesModel? ServiceStatuses { get; set; }

    [JsonPropertyName("status")]
    public StatusTypesConstant? Status { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }

    [JsonPropertyName("vmUuid")]
    public string? VMUuid { get; set; }
}
