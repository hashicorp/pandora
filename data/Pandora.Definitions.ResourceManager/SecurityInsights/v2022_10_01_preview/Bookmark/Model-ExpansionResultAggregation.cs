using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Bookmark;


internal class ExpansionResultAggregationModel
{
    [JsonPropertyName("aggregationType")]
    public string? AggregationType { get; set; }

    [JsonPropertyName("count")]
    [Required]
    public int Count { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("entityKind")]
    [Required]
    public EntityKindConstant EntityKind { get; set; }
}
