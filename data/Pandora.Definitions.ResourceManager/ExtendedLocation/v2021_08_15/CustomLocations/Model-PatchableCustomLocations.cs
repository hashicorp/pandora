using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ExtendedLocation.v2021_08_15.CustomLocations;


internal class PatchableCustomLocationsModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.SystemAssignedIdentity? Identity { get; set; }

    [JsonPropertyName("properties")]
    public CustomLocationPropertiesModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
