// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsInformationProtectionDesktopAppModel
{
    [JsonPropertyName("binaryName")]
    public string? BinaryName { get; set; }

    [JsonPropertyName("binaryVersionHigh")]
    public string? BinaryVersionHigh { get; set; }

    [JsonPropertyName("binaryVersionLow")]
    public string? BinaryVersionLow { get; set; }

    [JsonPropertyName("denied")]
    public bool? Denied { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("publisherName")]
    public string? PublisherName { get; set; }
}
