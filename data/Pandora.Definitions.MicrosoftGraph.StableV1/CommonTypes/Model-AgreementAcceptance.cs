// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AgreementAcceptanceModel
{
    [JsonPropertyName("agreementFileId")]
    public string? AgreementFileId { get; set; }

    [JsonPropertyName("agreementId")]
    public string? AgreementId { get; set; }

    [JsonPropertyName("deviceDisplayName")]
    public string? DeviceDisplayName { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceOSType")]
    public string? DeviceOSType { get; set; }

    [JsonPropertyName("deviceOSVersion")]
    public string? DeviceOSVersion { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recordedDateTime")]
    public DateTime? RecordedDateTime { get; set; }

    [JsonPropertyName("state")]
    public AgreementAcceptanceStateConstant? State { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userEmail")]
    public string? UserEmail { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
