using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationMigrationItems;


internal class VMwareCbtNicInputModel
{
    [JsonPropertyName("isPrimaryNic")]
    [Required]
    public string IsPrimaryNic { get; set; }

    [JsonPropertyName("isSelectedForMigration")]
    public string? IsSelectedForMigration { get; set; }

    [JsonPropertyName("nicId")]
    [Required]
    public string NicId { get; set; }

    [JsonPropertyName("targetNicName")]
    public string? TargetNicName { get; set; }

    [JsonPropertyName("targetStaticIPAddress")]
    public string? TargetStaticIPAddress { get; set; }

    [JsonPropertyName("targetSubnetName")]
    public string? TargetSubnetName { get; set; }

    [JsonPropertyName("testStaticIPAddress")]
    public string? TestStaticIPAddress { get; set; }

    [JsonPropertyName("testSubnetName")]
    public string? TestSubnetName { get; set; }
}
