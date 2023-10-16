using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_07_01.MHSMListRegions;


internal class MHSMGeoReplicatedRegionModel
{
    [JsonPropertyName("isPrimary")]
    public bool? IsPrimary { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("provisioningState")]
    public GeoReplicationRegionProvisioningStateConstant? ProvisioningState { get; set; }
}
