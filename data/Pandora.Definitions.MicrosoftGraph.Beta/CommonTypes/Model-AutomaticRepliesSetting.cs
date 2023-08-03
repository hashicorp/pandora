// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AutomaticRepliesSettingModel
{
    [JsonPropertyName("externalAudience")]
    public ExternalAudienceScopeConstant? ExternalAudience { get; set; }

    [JsonPropertyName("externalReplyMessage")]
    public string? ExternalReplyMessage { get; set; }

    [JsonPropertyName("internalReplyMessage")]
    public string? InternalReplyMessage { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scheduledEndDateTime")]
    public DateTimeTimeZoneModel? ScheduledEndDateTime { get; set; }

    [JsonPropertyName("scheduledStartDateTime")]
    public DateTimeTimeZoneModel? ScheduledStartDateTime { get; set; }

    [JsonPropertyName("status")]
    public AutomaticRepliesStatusConstant? Status { get; set; }
}
