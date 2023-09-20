// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class StrongAuthenticationPhoneAppDetailModel
{
    [JsonPropertyName("authenticationType")]
    public string? AuthenticationType { get; set; }

    [JsonPropertyName("authenticatorFlavor")]
    public string? AuthenticatorFlavor { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceTag")]
    public string? DeviceTag { get; set; }

    [JsonPropertyName("deviceToken")]
    public string? DeviceToken { get; set; }

    [JsonPropertyName("hashFunction")]
    public string? HashFunction { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastAuthenticatedDateTime")]
    public DateTime? LastAuthenticatedDateTime { get; set; }

    [JsonPropertyName("notificationType")]
    public string? NotificationType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oathSecretKey")]
    public string? OathSecretKey { get; set; }

    [JsonPropertyName("oathTokenMetadata")]
    public OathTokenMetadataModel? OathTokenMetadata { get; set; }

    [JsonPropertyName("oathTokenTimeDriftInSeconds")]
    public int? OathTokenTimeDriftInSeconds { get; set; }

    [JsonPropertyName("phoneAppVersion")]
    public string? PhoneAppVersion { get; set; }

    [JsonPropertyName("tenantDeviceId")]
    public string? TenantDeviceId { get; set; }

    [JsonPropertyName("tokenGenerationIntervalInSeconds")]
    public int? TokenGenerationIntervalInSeconds { get; set; }
}
