// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkActivePeripheralsModel
{
    [JsonPropertyName("communicationSpeaker")]
    public TeamworkPeripheralModel? CommunicationSpeaker { get; set; }

    [JsonPropertyName("contentCamera")]
    public TeamworkPeripheralModel? ContentCamera { get; set; }

    [JsonPropertyName("microphone")]
    public TeamworkPeripheralModel? Microphone { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roomCamera")]
    public TeamworkPeripheralModel? RoomCamera { get; set; }

    [JsonPropertyName("speaker")]
    public TeamworkPeripheralModel? Speaker { get; set; }
}
