// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AssignmentFilterSupportedPropertyModel
{
    [JsonPropertyName("dataType")]
    public string? DataType { get; set; }

    [JsonPropertyName("isCollection")]
    public bool? IsCollection { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("propertyRegexConstraint")]
    public string? PropertyRegexConstraint { get; set; }

    [JsonPropertyName("supportedOperators")]
    public List<AssignmentFilterOperatorConstant>? SupportedOperators { get; set; }

    [JsonPropertyName("supportedValues")]
    public List<string>? SupportedValues { get; set; }
}
