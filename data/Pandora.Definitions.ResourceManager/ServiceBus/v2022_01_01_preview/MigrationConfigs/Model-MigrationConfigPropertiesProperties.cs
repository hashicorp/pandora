using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.MigrationConfigs;


internal class MigrationConfigPropertiesPropertiesModel
{
    [JsonPropertyName("migrationState")]
    public string? MigrationState { get; set; }

    [JsonPropertyName("pendingReplicationOperationsCount")]
    public int? PendingReplicationOperationsCount { get; set; }

    [JsonPropertyName("postMigrationName")]
    [Required]
    public string PostMigrationName { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("targetNamespace")]
    [Required]
    public string TargetNamespace { get; set; }
}
