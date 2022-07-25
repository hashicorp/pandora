using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.Workspaces;


internal class SearchSchemaValueModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("facet")]
    [Required]
    public bool Facet { get; set; }

    [JsonPropertyName("indexed")]
    [Required]
    public bool Indexed { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("ownerType")]
    public List<string>? OwnerType { get; set; }

    [JsonPropertyName("stored")]
    [Required]
    public bool Stored { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
