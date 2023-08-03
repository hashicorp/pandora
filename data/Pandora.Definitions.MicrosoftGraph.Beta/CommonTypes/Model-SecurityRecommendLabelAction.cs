// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityRecommendLabelActionModel
{
    [JsonPropertyName("actionSource")]
    public ActionSourceConstant? ActionSource { get; set; }

    [JsonPropertyName("actions")]
    public List<InformationProtectionActionModel>? Actions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("responsibleSensitiveTypeIds")]
    public List<string>? ResponsibleSensitiveTypeIds { get; set; }

    [JsonPropertyName("sensitivityLabelId")]
    public string? SensitivityLabelId { get; set; }
}
