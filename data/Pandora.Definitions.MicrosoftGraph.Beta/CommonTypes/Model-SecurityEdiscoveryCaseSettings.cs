// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityEdiscoveryCaseSettingsModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ocr")]
    public SecurityOcrSettingsModel? Ocr { get; set; }

    [JsonPropertyName("redundancyDetection")]
    public SecurityRedundancyDetectionSettingsModel? RedundancyDetection { get; set; }

    [JsonPropertyName("topicModeling")]
    public SecurityTopicModelingSettingsModel? TopicModeling { get; set; }
}
