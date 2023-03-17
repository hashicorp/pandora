using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationFabrics;

[ValueForType("Azure")]
internal class AzureFabricSpecificDetailsModel : FabricSpecificDetailsModel
{
    [JsonPropertyName("containerIds")]
    public List<string>? ContainerIds { get; set; }

    [JsonPropertyName("extendedLocations")]
    public List<A2AExtendedLocationDetailsModel>? ExtendedLocations { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("locationDetails")]
    public List<A2AFabricSpecificLocationDetailsModel>? LocationDetails { get; set; }

    [JsonPropertyName("zones")]
    public List<A2AZoneDetailsModel>? Zones { get; set; }
}
