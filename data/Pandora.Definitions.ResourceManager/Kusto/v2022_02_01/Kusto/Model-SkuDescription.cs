using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.Kusto;


internal class SkuDescriptionModel
{
    [JsonPropertyName("locationInfo")]
    public List<SkuLocationInfoItemModel>? LocationInfo { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("restrictions")]
    public List<object>? Restrictions { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }
}
