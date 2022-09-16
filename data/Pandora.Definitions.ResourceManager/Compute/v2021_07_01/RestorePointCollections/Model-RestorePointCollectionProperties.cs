using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.RestorePointCollections;


internal class RestorePointCollectionPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("restorePointCollectionId")]
    public string? RestorePointCollectionId { get; set; }

    [JsonPropertyName("restorePoints")]
    public List<RestorePointModel>? RestorePoints { get; set; }

    [JsonPropertyName("source")]
    public RestorePointCollectionSourcePropertiesModel? Source { get; set; }
}
