// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EmailThreatSubmissionPolicyModel
{
    [JsonPropertyName("customizedNotificationSenderEmailAddress")]
    public string? CustomizedNotificationSenderEmailAddress { get; set; }

    [JsonPropertyName("customizedReportRecipientEmailAddress")]
    public string? CustomizedReportRecipientEmailAddress { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAlwaysReportEnabledForUsers")]
    public bool? IsAlwaysReportEnabledForUsers { get; set; }

    [JsonPropertyName("isAskMeEnabledForUsers")]
    public bool? IsAskMeEnabledForUsers { get; set; }

    [JsonPropertyName("isCustomizedMessageEnabled")]
    public bool? IsCustomizedMessageEnabled { get; set; }

    [JsonPropertyName("isCustomizedMessageEnabledForPhishing")]
    public bool? IsCustomizedMessageEnabledForPhishing { get; set; }

    [JsonPropertyName("isCustomizedNotificationSenderEnabled")]
    public bool? IsCustomizedNotificationSenderEnabled { get; set; }

    [JsonPropertyName("isNeverReportEnabledForUsers")]
    public bool? IsNeverReportEnabledForUsers { get; set; }

    [JsonPropertyName("isOrganizationBrandingEnabled")]
    public bool? IsOrganizationBrandingEnabled { get; set; }

    [JsonPropertyName("isReportFromQuarantineEnabled")]
    public bool? IsReportFromQuarantineEnabled { get; set; }

    [JsonPropertyName("isReportToCustomizedEmailAddressEnabled")]
    public bool? IsReportToCustomizedEmailAddressEnabled { get; set; }

    [JsonPropertyName("isReportToMicrosoftEnabled")]
    public bool? IsReportToMicrosoftEnabled { get; set; }

    [JsonPropertyName("isReviewEmailNotificationEnabled")]
    public bool? IsReviewEmailNotificationEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
