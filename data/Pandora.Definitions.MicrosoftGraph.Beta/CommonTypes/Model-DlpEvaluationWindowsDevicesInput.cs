// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DlpEvaluationWindowsDevicesInputModel
{
    [JsonPropertyName("contentProperties")]
    public ContentPropertiesModel? ContentProperties { get; set; }

    [JsonPropertyName("currentLabel")]
    public CurrentLabelModel? CurrentLabel { get; set; }

    [JsonPropertyName("discoveredSensitiveTypes")]
    public List<DiscoveredSensitiveTypeModel>? DiscoveredSensitiveTypes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sharedBy")]
    public string? SharedBy { get; set; }
}
