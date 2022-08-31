using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.LiveEvents;


internal class LiveEventTranscriptionModel
{
    [JsonPropertyName("inputTrackSelection")]
    public List<LiveEventInputTrackSelectionModel>? InputTrackSelection { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("outputTranscriptionTrack")]
    public LiveEventOutputTranscriptionTrackModel? OutputTranscriptionTrack { get; set; }
}
