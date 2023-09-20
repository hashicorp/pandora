// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDevice;

internal class CreateMeManagedDeviceByIdOverrideComplianceStateRequestModel
{
    [JsonPropertyName("complianceState")]
    public CreateMeManagedDeviceByIdOverrideComplianceStateRequestComplianceStateConstant? ComplianceState { get; set; }

    [JsonPropertyName("remediationUrl")]
    public string? RemediationUrl { get; set; }
}
