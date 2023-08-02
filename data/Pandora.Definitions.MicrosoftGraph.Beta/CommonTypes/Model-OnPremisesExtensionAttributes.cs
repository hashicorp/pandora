// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesExtensionAttributesModel
{
    [JsonPropertyName("extensionAttribute1")]
    public string? ExtensionAttribute1 { get; set; }

    [JsonPropertyName("extensionAttribute10")]
    public string? ExtensionAttribute10 { get; set; }

    [JsonPropertyName("extensionAttribute11")]
    public string? ExtensionAttribute11 { get; set; }

    [JsonPropertyName("extensionAttribute12")]
    public string? ExtensionAttribute12 { get; set; }

    [JsonPropertyName("extensionAttribute13")]
    public string? ExtensionAttribute13 { get; set; }

    [JsonPropertyName("extensionAttribute14")]
    public string? ExtensionAttribute14 { get; set; }

    [JsonPropertyName("extensionAttribute15")]
    public string? ExtensionAttribute15 { get; set; }

    [JsonPropertyName("extensionAttribute2")]
    public string? ExtensionAttribute2 { get; set; }

    [JsonPropertyName("extensionAttribute3")]
    public string? ExtensionAttribute3 { get; set; }

    [JsonPropertyName("extensionAttribute4")]
    public string? ExtensionAttribute4 { get; set; }

    [JsonPropertyName("extensionAttribute5")]
    public string? ExtensionAttribute5 { get; set; }

    [JsonPropertyName("extensionAttribute6")]
    public string? ExtensionAttribute6 { get; set; }

    [JsonPropertyName("extensionAttribute7")]
    public string? ExtensionAttribute7 { get; set; }

    [JsonPropertyName("extensionAttribute8")]
    public string? ExtensionAttribute8 { get; set; }

    [JsonPropertyName("extensionAttribute9")]
    public string? ExtensionAttribute9 { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
