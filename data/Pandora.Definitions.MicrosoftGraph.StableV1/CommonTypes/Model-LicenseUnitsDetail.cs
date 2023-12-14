// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class LicenseUnitsDetailModel
{
    [JsonPropertyName("enabled")]
    public int? Enabled { get; set; }

    [JsonPropertyName("lockedOut")]
    public int? LockedOut { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("suspended")]
    public int? Suspended { get; set; }

    [JsonPropertyName("warning")]
    public int? Warning { get; set; }
}
