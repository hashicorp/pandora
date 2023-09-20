// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationAssignmentDefaultsModel
{
    [JsonPropertyName("addToCalendarAction")]
    public EducationAssignmentDefaultsAddToCalendarActionConstant? AddToCalendarAction { get; set; }

    [JsonPropertyName("addedStudentAction")]
    public EducationAssignmentDefaultsAddedStudentActionConstant? AddedStudentAction { get; set; }

    [JsonPropertyName("dueTime")]
    public DateTime? DueTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("notificationChannelUrl")]
    public string? NotificationChannelUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
