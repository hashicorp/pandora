using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2020_12_01.Endpoints;

[ValueForType("EventGrid")]
internal class EventGridModel : DigitalTwinsEndpointResourcePropertiesModel
{
    [JsonPropertyName("accessKey1")]
    public string? AccessKey1 { get; set; }

    [JsonPropertyName("accessKey2")]
    public string? AccessKey2 { get; set; }

    [JsonPropertyName("TopicEndpoint")]
    public string? TopicEndpoint { get; set; }
}
