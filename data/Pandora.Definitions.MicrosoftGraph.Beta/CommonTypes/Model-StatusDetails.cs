// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class StatusDetailsModel
{
    [JsonPropertyName("additionalDetails")]
    public string? AdditionalDetails { get; set; }

    [JsonPropertyName("errorCategory")]
    public ProvisioningStatusErrorCategoryConstant? ErrorCategory { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("recommendedAction")]
    public string? RecommendedAction { get; set; }

    [JsonPropertyName("status")]
    public ProvisioningResultConstant? Status { get; set; }
}
