// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementDerivedCredentialSettingsModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("helpUrl")]
    public string? HelpUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issuer")]
    public DeviceManagementDerivedCredentialSettingsIssuerConstant? Issuer { get; set; }

    [JsonPropertyName("notificationType")]
    public DeviceManagementDerivedCredentialSettingsNotificationTypeConstant? NotificationType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("renewalThresholdPercentage")]
    public int? RenewalThresholdPercentage { get; set; }
}
