using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.StreamingPoliciesAndStreamingLocators;


internal class EnabledProtocolsModel
{
    [JsonPropertyName("dash")]
    [Required]
    public bool Dash { get; set; }

    [JsonPropertyName("download")]
    [Required]
    public bool Download { get; set; }

    [JsonPropertyName("hls")]
    [Required]
    public bool Hls { get; set; }

    [JsonPropertyName("smoothStreaming")]
    [Required]
    public bool SmoothStreaming { get; set; }
}
