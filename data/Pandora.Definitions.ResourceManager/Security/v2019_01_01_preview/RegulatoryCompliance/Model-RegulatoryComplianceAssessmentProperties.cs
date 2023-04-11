using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.RegulatoryCompliance;


internal class RegulatoryComplianceAssessmentPropertiesModel
{
    [JsonPropertyName("assessmentDetailsLink")]
    public string? AssessmentDetailsLink { get; set; }

    [JsonPropertyName("assessmentType")]
    public string? AssessmentType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("failedResources")]
    public int? FailedResources { get; set; }

    [JsonPropertyName("passedResources")]
    public int? PassedResources { get; set; }

    [JsonPropertyName("skippedResources")]
    public int? SkippedResources { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }

    [JsonPropertyName("unsupportedResources")]
    public int? UnsupportedResources { get; set; }
}
