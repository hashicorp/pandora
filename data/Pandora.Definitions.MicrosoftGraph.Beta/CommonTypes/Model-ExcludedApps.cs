// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExcludedAppsModel
{
    [JsonPropertyName("access")]
    public bool? Access { get; set; }

    [JsonPropertyName("bing")]
    public bool? Bing { get; set; }

    [JsonPropertyName("excel")]
    public bool? Excel { get; set; }

    [JsonPropertyName("groove")]
    public bool? Groove { get; set; }

    [JsonPropertyName("infoPath")]
    public bool? InfoPath { get; set; }

    [JsonPropertyName("lync")]
    public bool? Lync { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oneDrive")]
    public bool? OneDrive { get; set; }

    [JsonPropertyName("oneNote")]
    public bool? OneNote { get; set; }

    [JsonPropertyName("outlook")]
    public bool? Outlook { get; set; }

    [JsonPropertyName("powerPoint")]
    public bool? PowerPoint { get; set; }

    [JsonPropertyName("publisher")]
    public bool? Publisher { get; set; }

    [JsonPropertyName("sharePointDesigner")]
    public bool? SharePointDesigner { get; set; }

    [JsonPropertyName("teams")]
    public bool? Teams { get; set; }

    [JsonPropertyName("visio")]
    public bool? Visio { get; set; }

    [JsonPropertyName("word")]
    public bool? Word { get; set; }
}
