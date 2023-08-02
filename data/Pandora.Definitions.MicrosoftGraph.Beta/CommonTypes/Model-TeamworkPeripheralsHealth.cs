// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkPeripheralsHealthModel
{
    [JsonPropertyName("communicationSpeakerHealth")]
    public TeamworkPeripheralHealthModel? CommunicationSpeakerHealth { get; set; }

    [JsonPropertyName("contentCameraHealth")]
    public TeamworkPeripheralHealthModel? ContentCameraHealth { get; set; }

    [JsonPropertyName("displayHealthCollection")]
    public List<TeamworkPeripheralHealthModel>? DisplayHealthCollection { get; set; }

    [JsonPropertyName("microphoneHealth")]
    public TeamworkPeripheralHealthModel? MicrophoneHealth { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roomCameraHealth")]
    public TeamworkPeripheralHealthModel? RoomCameraHealth { get; set; }

    [JsonPropertyName("speakerHealth")]
    public TeamworkPeripheralHealthModel? SpeakerHealth { get; set; }
}
