// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MeetingRegistrationModel
{
    [JsonPropertyName("allowedRegistrant")]
    public MeetingRegistrationAllowedRegistrantConstant? AllowedRegistrant { get; set; }

    [JsonPropertyName("customQuestions")]
    public List<MeetingRegistrationQuestionModel>? CustomQuestions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("registrants")]
    public List<MeetingRegistrantBaseModel>? Registrants { get; set; }

    [JsonPropertyName("registrationPageViewCount")]
    public int? RegistrationPageViewCount { get; set; }

    [JsonPropertyName("registrationPageWebUrl")]
    public string? RegistrationPageWebUrl { get; set; }

    [JsonPropertyName("speakers")]
    public List<MeetingSpeakerModel>? Speakers { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }
}
