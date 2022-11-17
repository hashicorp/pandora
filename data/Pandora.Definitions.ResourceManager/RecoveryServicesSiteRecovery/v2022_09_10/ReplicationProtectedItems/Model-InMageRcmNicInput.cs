using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;


internal class InMageRcmNicInputModel
{
    [JsonPropertyName("isPrimaryNic")]
    [Required]
    public string IsPrimaryNic { get; set; }

    [JsonPropertyName("isSelectedForFailover")]
    public string? IsSelectedForFailover { get; set; }

    [JsonPropertyName("nicId")]
    [Required]
    public string NicId { get; set; }

    [JsonPropertyName("targetStaticIPAddress")]
    public string? TargetStaticIPAddress { get; set; }

    [JsonPropertyName("targetSubnetName")]
    public string? TargetSubnetName { get; set; }

    [JsonPropertyName("testStaticIPAddress")]
    public string? TestStaticIPAddress { get; set; }

    [JsonPropertyName("testSubnetName")]
    public string? TestSubnetName { get; set; }
}
