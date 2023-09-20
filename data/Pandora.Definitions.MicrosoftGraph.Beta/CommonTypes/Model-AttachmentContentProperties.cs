// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AttachmentContentPropertiesModel
{
    [JsonPropertyName("currentLabel")]
    public CurrentLabelModel? CurrentLabel { get; set; }

    [JsonPropertyName("discoveredSensitiveTypes")]
    public List<DiscoveredSensitiveTypeModel>? DiscoveredSensitiveTypes { get; set; }

    [JsonPropertyName("extensions")]
    public List<string>? Extensions { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("metadata")]
    public ContentMetadataModel? Metadata { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
