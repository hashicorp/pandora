using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveEvents;


internal class LiveEventInputModel
{
    [JsonPropertyName("accessControl")]
    public LiveEventInputAccessControlModel? AccessControl { get; set; }

    [JsonPropertyName("accessToken")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("endpoints")]
    public List<LiveEventEndpointModel>? Endpoints { get; set; }

    [JsonPropertyName("keyFrameIntervalDuration")]
    public string? KeyFrameIntervalDuration { get; set; }

    [JsonPropertyName("streamingProtocol")]
    [Required]
    public LiveEventInputProtocolConstant StreamingProtocol { get; set; }
}
