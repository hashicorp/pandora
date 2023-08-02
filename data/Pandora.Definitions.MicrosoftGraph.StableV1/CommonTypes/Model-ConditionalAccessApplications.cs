// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConditionalAccessApplicationsModel
{
    [JsonPropertyName("excludeApplications")]
    public List<string>? ExcludeApplications { get; set; }

    [JsonPropertyName("includeApplications")]
    public List<string>? IncludeApplications { get; set; }

    [JsonPropertyName("includeAuthenticationContextClassReferences")]
    public List<string>? IncludeAuthenticationContextClassReferences { get; set; }

    [JsonPropertyName("includeUserActions")]
    public List<string>? IncludeUserActions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
