using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectionContainerMappings;


internal class ProtectionContainerMappingPropertiesModel
{
    [JsonPropertyName("health")]
    public string? Health { get; set; }

    [JsonPropertyName("healthErrorDetails")]
    public List<HealthErrorModel>? HealthErrorDetails { get; set; }

    [JsonPropertyName("policyFriendlyName")]
    public string? PolicyFriendlyName { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public ProtectionContainerMappingProviderSpecificDetailsModel? ProviderSpecificDetails { get; set; }

    [JsonPropertyName("sourceFabricFriendlyName")]
    public string? SourceFabricFriendlyName { get; set; }

    [JsonPropertyName("sourceProtectionContainerFriendlyName")]
    public string? SourceProtectionContainerFriendlyName { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("targetFabricFriendlyName")]
    public string? TargetFabricFriendlyName { get; set; }

    [JsonPropertyName("targetProtectionContainerFriendlyName")]
    public string? TargetProtectionContainerFriendlyName { get; set; }

    [JsonPropertyName("targetProtectionContainerId")]
    public string? TargetProtectionContainerId { get; set; }
}
