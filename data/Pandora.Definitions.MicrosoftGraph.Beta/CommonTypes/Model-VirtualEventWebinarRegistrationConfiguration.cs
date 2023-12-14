// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VirtualEventWebinarRegistrationConfigurationModel
{
    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isManualApprovalEnabled")]
    public bool? IsManualApprovalEnabled { get; set; }

    [JsonPropertyName("isWaitlistEnabled")]
    public bool? IsWaitlistEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("questions")]
    public List<VirtualEventRegistrationQuestionBaseModel>? Questions { get; set; }

    [JsonPropertyName("registrationWebUrl")]
    public string? RegistrationWebUrl { get; set; }
}
