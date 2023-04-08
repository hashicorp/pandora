using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.Assessments;


internal class AssessmentStatusResponseModel
{
    [JsonPropertyName("cause")]
    public string? Cause { get; set; }

    [JsonPropertyName("code")]
    [Required]
    public AssessmentStatusCodeConstant Code { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("firstEvaluationDate")]
    public DateTime? FirstEvaluationDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("statusChangeDate")]
    public DateTime? StatusChangeDate { get; set; }
}
