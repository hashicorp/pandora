using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.RegulatoryCompliance;


internal class RegulatoryComplianceControlPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("failedAssessments")]
    public int? FailedAssessments { get; set; }

    [JsonPropertyName("passedAssessments")]
    public int? PassedAssessments { get; set; }

    [JsonPropertyName("skippedAssessments")]
    public int? SkippedAssessments { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }
}
