// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MobileThreatDefenseConnectorModel
{
    [JsonPropertyName("allowPartnerToCollectIOSApplicationMetadata")]
    public bool? AllowPartnerToCollectIOSApplicationMetadata { get; set; }

    [JsonPropertyName("allowPartnerToCollectIOSPersonalApplicationMetadata")]
    public bool? AllowPartnerToCollectIOSPersonalApplicationMetadata { get; set; }

    [JsonPropertyName("androidDeviceBlockedOnMissingPartnerData")]
    public bool? AndroidDeviceBlockedOnMissingPartnerData { get; set; }

    [JsonPropertyName("androidEnabled")]
    public bool? AndroidEnabled { get; set; }

    [JsonPropertyName("androidMobileApplicationManagementEnabled")]
    public bool? AndroidMobileApplicationManagementEnabled { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("iosDeviceBlockedOnMissingPartnerData")]
    public bool? IosDeviceBlockedOnMissingPartnerData { get; set; }

    [JsonPropertyName("iosEnabled")]
    public bool? IosEnabled { get; set; }

    [JsonPropertyName("iosMobileApplicationManagementEnabled")]
    public bool? IosMobileApplicationManagementEnabled { get; set; }

    [JsonPropertyName("lastHeartbeatDateTime")]
    public DateTime? LastHeartbeatDateTime { get; set; }

    [JsonPropertyName("microsoftDefenderForEndpointAttachEnabled")]
    public bool? MicrosoftDefenderForEndpointAttachEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("partnerState")]
    public MobileThreatPartnerTenantStateConstant? PartnerState { get; set; }

    [JsonPropertyName("partnerUnresponsivenessThresholdInDays")]
    public int? PartnerUnresponsivenessThresholdInDays { get; set; }

    [JsonPropertyName("partnerUnsupportedOsVersionBlocked")]
    public bool? PartnerUnsupportedOsVersionBlocked { get; set; }

    [JsonPropertyName("windowsDeviceBlockedOnMissingPartnerData")]
    public bool? WindowsDeviceBlockedOnMissingPartnerData { get; set; }

    [JsonPropertyName("windowsEnabled")]
    public bool? WindowsEnabled { get; set; }
}
