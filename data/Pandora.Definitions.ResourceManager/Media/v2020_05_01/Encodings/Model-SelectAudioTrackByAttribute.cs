using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ValueForType("#Microsoft.Media.SelectAudioTrackByAttribute")]
internal class SelectAudioTrackByAttributeModel : TrackDescriptorModel
{
    [JsonPropertyName("attribute")]
    [Required]
    public TrackAttributeConstant Attribute { get; set; }

    [JsonPropertyName("channelMapping")]
    public ChannelMappingConstant? ChannelMapping { get; set; }

    [JsonPropertyName("filter")]
    [Required]
    public AttributeFilterConstant Filter { get; set; }

    [JsonPropertyName("filterValue")]
    public string? FilterValue { get; set; }
}
