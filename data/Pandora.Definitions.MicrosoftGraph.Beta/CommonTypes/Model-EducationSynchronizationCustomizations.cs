// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationSynchronizationCustomizationsModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("school")]
    public EducationSynchronizationCustomizationModel? School { get; set; }

    [JsonPropertyName("section")]
    public EducationSynchronizationCustomizationModel? Section { get; set; }

    [JsonPropertyName("student")]
    public EducationSynchronizationCustomizationModel? Student { get; set; }

    [JsonPropertyName("studentEnrollment")]
    public EducationSynchronizationCustomizationModel? StudentEnrollment { get; set; }

    [JsonPropertyName("teacher")]
    public EducationSynchronizationCustomizationModel? Teacher { get; set; }

    [JsonPropertyName("teacherRoster")]
    public EducationSynchronizationCustomizationModel? TeacherRoster { get; set; }
}
