// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ApplicationDetailModel
{
    [JsonPropertyName("fileDescription")]
    public string? FileDescription { get; set; }

    [JsonPropertyName("fileHash")]
    public string? FileHash { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productInternalName")]
    public string? ProductInternalName { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("productVersion")]
    public string? ProductVersion { get; set; }

    [JsonPropertyName("publisherName")]
    public string? PublisherName { get; set; }
}
