using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationFabrics;


internal class FabricPropertiesModel
{
    [JsonPropertyName("bcdrState")]
    public string? BcdrState { get; set; }

    [JsonPropertyName("customDetails")]
    public FabricSpecificDetailsModel? CustomDetails { get; set; }

    [JsonPropertyName("encryptionDetails")]
    public EncryptionDetailsModel? EncryptionDetails { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("health")]
    public string? Health { get; set; }

    [JsonPropertyName("healthErrorDetails")]
    public List<HealthErrorModel>? HealthErrorDetails { get; set; }

    [JsonPropertyName("internalIdentifier")]
    public string? InternalIdentifier { get; set; }

    [JsonPropertyName("rolloverEncryptionDetails")]
    public EncryptionDetailsModel? RolloverEncryptionDetails { get; set; }
}
