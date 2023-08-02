// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkSpeakerConfigurationModel
{
    [JsonPropertyName("defaultCommunicationSpeaker")]
    public TeamworkPeripheralModel? DefaultCommunicationSpeaker { get; set; }

    [JsonPropertyName("defaultSpeaker")]
    public TeamworkPeripheralModel? DefaultSpeaker { get; set; }

    [JsonPropertyName("isCommunicationSpeakerOptional")]
    public bool? IsCommunicationSpeakerOptional { get; set; }

    [JsonPropertyName("isSpeakerOptional")]
    public bool? IsSpeakerOptional { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("speakers")]
    public List<TeamworkPeripheralModel>? Speakers { get; set; }
}
