using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationFabrics;


internal class A2AFabricSpecificLocationDetailsModel
{
    [JsonPropertyName("initialPrimaryExtendedLocation")]
    public CustomTypes.EdgeZone? InitialPrimaryExtendedLocation { get; set; }

    [JsonPropertyName("initialPrimaryFabricLocation")]
    public string? InitialPrimaryFabricLocation { get; set; }

    [JsonPropertyName("initialPrimaryZone")]
    public string? InitialPrimaryZone { get; set; }

    [JsonPropertyName("initialRecoveryExtendedLocation")]
    public CustomTypes.EdgeZone? InitialRecoveryExtendedLocation { get; set; }

    [JsonPropertyName("initialRecoveryFabricLocation")]
    public string? InitialRecoveryFabricLocation { get; set; }

    [JsonPropertyName("initialRecoveryZone")]
    public string? InitialRecoveryZone { get; set; }

    [JsonPropertyName("primaryExtendedLocation")]
    public CustomTypes.EdgeZone? PrimaryExtendedLocation { get; set; }

    [JsonPropertyName("primaryFabricLocation")]
    public string? PrimaryFabricLocation { get; set; }

    [JsonPropertyName("primaryZone")]
    public string? PrimaryZone { get; set; }

    [JsonPropertyName("recoveryExtendedLocation")]
    public CustomTypes.EdgeZone? RecoveryExtendedLocation { get; set; }

    [JsonPropertyName("recoveryFabricLocation")]
    public string? RecoveryFabricLocation { get; set; }

    [JsonPropertyName("recoveryZone")]
    public string? RecoveryZone { get; set; }
}
