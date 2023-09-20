// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OmaSettingIntegerModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("isEncrypted")]
    public bool? IsEncrypted { get; set; }

    [JsonPropertyName("isReadOnly")]
    public bool? IsReadOnly { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("omaUri")]
    public string? OmaUri { get; set; }

    [JsonPropertyName("secretReferenceValueId")]
    public string? SecretReferenceValueId { get; set; }

    [JsonPropertyName("value")]
    public int? Value { get; set; }
}
