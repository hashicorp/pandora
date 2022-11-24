using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("A2ACrossClusterMigration")]
internal class A2ACrossClusterMigrationReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [JsonPropertyName("fabricObjectId")]
    public string? FabricObjectId { get; set; }

    [JsonPropertyName("lifecycleId")]
    public string? LifecycleId { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("primaryFabricLocation")]
    public string? PrimaryFabricLocation { get; set; }

    [JsonPropertyName("vmProtectionState")]
    public string? VmProtectionState { get; set; }

    [JsonPropertyName("vmProtectionStateDescription")]
    public string? VmProtectionStateDescription { get; set; }
}
