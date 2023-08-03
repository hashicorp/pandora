// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AdminConsentRequestPolicyModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("notifyReviewers")]
    public bool? NotifyReviewers { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remindersEnabled")]
    public bool? RemindersEnabled { get; set; }

    [JsonPropertyName("requestDurationInDays")]
    public int? RequestDurationInDays { get; set; }

    [JsonPropertyName("reviewers")]
    public List<AccessReviewReviewerScopeModel>? Reviewers { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
