using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.IotCentral.v2021_11_01_preview.Apps;


internal class AppTemplateModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("industry")]
    public string? Industry { get; set; }

    [JsonPropertyName("locations")]
    public List<AppTemplateLocationsModel>? Locations { get; set; }

    [JsonPropertyName("manifestId")]
    public string? ManifestId { get; set; }

    [JsonPropertyName("manifestVersion")]
    public string? ManifestVersion { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("order")]
    public float? Order { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
