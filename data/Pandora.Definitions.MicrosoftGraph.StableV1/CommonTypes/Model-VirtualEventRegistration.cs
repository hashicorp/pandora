// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class VirtualEventRegistrationModel
{
    [JsonPropertyName("cancelationDateTime")]
    public DateTime? CancelationDateTime { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("registrationDateTime")]
    public DateTime? RegistrationDateTime { get; set; }

    [JsonPropertyName("registrationQuestionAnswers")]
    public List<VirtualEventRegistrationQuestionAnswerModel>? RegistrationQuestionAnswers { get; set; }

    [JsonPropertyName("status")]
    public VirtualEventRegistrationStatusConstant? Status { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
