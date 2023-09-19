// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VppTokenRevokeLicensesActionResultModel
{
    [JsonPropertyName("actionFailureReason")]
    public VppTokenRevokeLicensesActionResultActionFailureReasonConstant? ActionFailureReason { get; set; }

    [JsonPropertyName("actionName")]
    public string? ActionName { get; set; }

    [JsonPropertyName("actionState")]
    public VppTokenRevokeLicensesActionResultActionStateConstant? ActionState { get; set; }

    [JsonPropertyName("failedLicensesCount")]
    public int? FailedLicensesCount { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("totalLicensesCount")]
    public int? TotalLicensesCount { get; set; }
}
