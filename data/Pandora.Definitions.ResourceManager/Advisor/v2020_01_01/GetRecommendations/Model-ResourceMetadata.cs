using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.GetRecommendations;


internal class ResourceMetadataModel
{
    [JsonPropertyName("action")]
    public Dictionary<string, object>? Action { get; set; }

    [JsonPropertyName("plural")]
    public string? Plural { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("singular")]
    public string? Singular { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }
}
