// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExternalConnectorsPropertyRuleModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operation")]
    public ExternalConnectorsPropertyRuleOperationConstant? Operation { get; set; }

    [JsonPropertyName("property")]
    public string? Property { get; set; }

    [JsonPropertyName("values")]
    public List<string>? Values { get; set; }

    [JsonPropertyName("valuesJoinedBy")]
    public ExternalConnectorsPropertyRuleValuesJoinedByConstant? ValuesJoinedBy { get; set; }
}
