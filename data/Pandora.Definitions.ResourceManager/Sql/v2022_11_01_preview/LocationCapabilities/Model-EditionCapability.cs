using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.LocationCapabilities;


internal class EditionCapabilityModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("readScale")]
    public ReadScaleCapabilityModel? ReadScale { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedServiceLevelObjectives")]
    public List<ServiceObjectiveCapabilityModel>? SupportedServiceLevelObjectives { get; set; }

    [JsonPropertyName("supportedStorageCapabilities")]
    public List<StorageCapabilityModel>? SupportedStorageCapabilities { get; set; }

    [JsonPropertyName("zonePinning")]
    public bool? ZonePinning { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
