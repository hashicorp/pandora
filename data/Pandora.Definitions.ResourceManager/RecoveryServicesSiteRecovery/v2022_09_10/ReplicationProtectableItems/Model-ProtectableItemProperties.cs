using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectableItems;


internal class ProtectableItemPropertiesModel
{
    [JsonPropertyName("customDetails")]
    public ConfigurationSettingsModel? CustomDetails { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("protectionReadinessErrors")]
    public List<string>? ProtectionReadinessErrors { get; set; }

    [JsonPropertyName("protectionStatus")]
    public string? ProtectionStatus { get; set; }

    [JsonPropertyName("recoveryServicesProviderId")]
    public string? RecoveryServicesProviderId { get; set; }

    [JsonPropertyName("replicationProtectedItemId")]
    public string? ReplicationProtectedItemId { get; set; }

    [JsonPropertyName("supportedReplicationProviders")]
    public List<string>? SupportedReplicationProviders { get; set; }
}
