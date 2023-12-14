// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BuildVersionDetailsModel
{
    [JsonPropertyName("buildNumber")]
    public int? BuildNumber { get; set; }

    [JsonPropertyName("majorVersion")]
    public int? MajorVersion { get; set; }

    [JsonPropertyName("minorVersion")]
    public int? MinorVersion { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("updateBuildRevision")]
    public int? UpdateBuildRevision { get; set; }
}
