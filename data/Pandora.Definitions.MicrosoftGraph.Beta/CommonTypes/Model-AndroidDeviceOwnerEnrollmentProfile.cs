// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidDeviceOwnerEnrollmentProfileModel
{
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("configureWifi")]
    public bool? ConfigureWifi { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enrolledDeviceCount")]
    public int? EnrolledDeviceCount { get; set; }

    [JsonPropertyName("enrollmentMode")]
    public AndroidDeviceOwnerEnrollmentModeConstant? EnrollmentMode { get; set; }

    [JsonPropertyName("enrollmentTokenType")]
    public AndroidDeviceOwnerEnrollmentTokenTypeConstant? EnrollmentTokenType { get; set; }

    [JsonPropertyName("enrollmentTokenUsageCount")]
    public int? EnrollmentTokenUsageCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isTeamsDeviceProfile")]
    public bool? IsTeamsDeviceProfile { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("qrCodeContent")]
    public string? QrCodeContent { get; set; }

    [JsonPropertyName("qrCodeImage")]
    public MimeContentModel? QrCodeImage { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("tokenCreationDateTime")]
    public DateTime? TokenCreationDateTime { get; set; }

    [JsonPropertyName("tokenExpirationDateTime")]
    public DateTime? TokenExpirationDateTime { get; set; }

    [JsonPropertyName("tokenValue")]
    public string? TokenValue { get; set; }

    [JsonPropertyName("wifiHidden")]
    public bool? WifiHidden { get; set; }

    [JsonPropertyName("wifiPassword")]
    public string? WifiPassword { get; set; }

    [JsonPropertyName("wifiSecurityType")]
    public AospWifiSecurityTypeConstant? WifiSecurityType { get; set; }

    [JsonPropertyName("wifiSsid")]
    public string? WifiSsid { get; set; }
}
