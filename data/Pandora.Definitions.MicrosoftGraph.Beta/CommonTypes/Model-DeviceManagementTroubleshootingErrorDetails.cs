// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementTroubleshootingErrorDetailsModel
{
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    [JsonPropertyName("failure")]
    public string? Failure { get; set; }

    [JsonPropertyName("failureDetails")]
    public string? FailureDetails { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remediation")]
    public string? Remediation { get; set; }

    [JsonPropertyName("resources")]
    public List<DeviceManagementTroubleshootingErrorResourceModel>? Resources { get; set; }
}
