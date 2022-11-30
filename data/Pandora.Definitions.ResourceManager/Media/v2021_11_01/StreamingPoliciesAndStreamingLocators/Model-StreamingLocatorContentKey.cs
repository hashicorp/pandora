using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.StreamingPoliciesAndStreamingLocators;


internal class StreamingLocatorContentKeyModel
{
    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("labelReferenceInStreamingPolicy")]
    public string? LabelReferenceInStreamingPolicy { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("tracks")]
    public List<TrackSelectionModel>? Tracks { get; set; }

    [JsonPropertyName("type")]
    public StreamingLocatorContentKeyTypeConstant? Type { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
