// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MailboxSettingsModel
{
    [JsonPropertyName("archiveFolder")]
    public string? ArchiveFolder { get; set; }

    [JsonPropertyName("automaticRepliesSetting")]
    public AutomaticRepliesSettingModel? AutomaticRepliesSetting { get; set; }

    [JsonPropertyName("dateFormat")]
    public string? DateFormat { get; set; }

    [JsonPropertyName("delegateMeetingMessageDeliveryOptions")]
    public DelegateMeetingMessageDeliveryOptionsConstant? DelegateMeetingMessageDeliveryOptions { get; set; }

    [JsonPropertyName("language")]
    public LocaleInfoModel? Language { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("timeFormat")]
    public string? TimeFormat { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("userPurpose")]
    public UserPurposeConstant? UserPurpose { get; set; }

    [JsonPropertyName("workingHours")]
    public WorkingHoursModel? WorkingHours { get; set; }
}
