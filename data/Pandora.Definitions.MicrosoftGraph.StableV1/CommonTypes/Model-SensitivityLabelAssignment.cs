// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SensitivityLabelAssignmentModel
{
    [JsonPropertyName("assignmentMethod")]
    public SensitivityLabelAssignmentAssignmentMethodConstant? AssignmentMethod { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sensitivityLabelId")]
    public string? SensitivityLabelId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
