// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationIdentityMatchingOptionsModel
{
    [JsonPropertyName("appliesTo")]
    public EducationIdentityMatchingOptionsAppliesToConstant? AppliesTo { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sourcePropertyName")]
    public string? SourcePropertyName { get; set; }

    [JsonPropertyName("targetDomain")]
    public string? TargetDomain { get; set; }

    [JsonPropertyName("targetPropertyName")]
    public string? TargetPropertyName { get; set; }
}
