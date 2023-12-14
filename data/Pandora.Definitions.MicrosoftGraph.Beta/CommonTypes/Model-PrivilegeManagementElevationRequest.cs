// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegeManagementElevationRequestModel
{
    [JsonPropertyName("applicationDetail")]
    public ApplicationDetailModel? ApplicationDetail { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestCreatedDateTime")]
    public DateTime? RequestCreatedDateTime { get; set; }

    [JsonPropertyName("requestExpiryDateTime")]
    public DateTime? RequestExpiryDateTime { get; set; }

    [JsonPropertyName("requestJustification")]
    public string? RequestJustification { get; set; }

    [JsonPropertyName("requestLastModifiedDateTime")]
    public DateTime? RequestLastModifiedDateTime { get; set; }

    [JsonPropertyName("requestedByUserId")]
    public string? RequestedByUserId { get; set; }

    [JsonPropertyName("requestedByUserPrincipalName")]
    public string? RequestedByUserPrincipalName { get; set; }

    [JsonPropertyName("requestedOnDeviceId")]
    public string? RequestedOnDeviceId { get; set; }

    [JsonPropertyName("reviewCompletedByUserId")]
    public string? ReviewCompletedByUserId { get; set; }

    [JsonPropertyName("reviewCompletedByUserPrincipalName")]
    public string? ReviewCompletedByUserPrincipalName { get; set; }

    [JsonPropertyName("reviewCompletedDateTime")]
    public DateTime? ReviewCompletedDateTime { get; set; }

    [JsonPropertyName("reviewerJustification")]
    public string? ReviewerJustification { get; set; }

    [JsonPropertyName("status")]
    public PrivilegeManagementElevationRequestStatusConstant? Status { get; set; }
}
