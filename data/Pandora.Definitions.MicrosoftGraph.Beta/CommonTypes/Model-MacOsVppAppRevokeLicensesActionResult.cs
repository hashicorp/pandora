// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOsVppAppRevokeLicensesActionResultModel
{
    [JsonPropertyName("actionFailureReason")]
    public MacOsVppAppRevokeLicensesActionResultActionFailureReasonConstant? ActionFailureReason { get; set; }

    [JsonPropertyName("actionName")]
    public string? ActionName { get; set; }

    [JsonPropertyName("actionState")]
    public MacOsVppAppRevokeLicensesActionResultActionStateConstant? ActionState { get; set; }

    [JsonPropertyName("failedLicensesCount")]
    public int? FailedLicensesCount { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("totalLicensesCount")]
    public int? TotalLicensesCount { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
