// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityLabelingOptionsModel
{
    [JsonPropertyName("assignmentMethod")]
    public SecurityLabelingOptionsAssignmentMethodConstant? AssignmentMethod { get; set; }

    [JsonPropertyName("downgradeJustification")]
    public SecurityDowngradeJustificationModel? DowngradeJustification { get; set; }

    [JsonPropertyName("extendedProperties")]
    public List<SecurityKeyValuePairModel>? ExtendedProperties { get; set; }

    [JsonPropertyName("labelId")]
    public string? LabelId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
