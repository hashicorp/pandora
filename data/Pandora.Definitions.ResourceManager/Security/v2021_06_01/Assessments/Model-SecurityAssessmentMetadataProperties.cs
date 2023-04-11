using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.Assessments;


internal class SecurityAssessmentMetadataPropertiesModel
{
    [JsonPropertyName("assessmentType")]
    [Required]
    public AssessmentTypeConstant AssessmentType { get; set; }

    [JsonPropertyName("categories")]
    public List<CategoriesConstant>? Categories { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("implementationEffort")]
    public ImplementationEffortConstant? ImplementationEffort { get; set; }

    [JsonPropertyName("partnerData")]
    public SecurityAssessmentMetadataPartnerDataModel? PartnerData { get; set; }

    [JsonPropertyName("policyDefinitionId")]
    public string? PolicyDefinitionId { get; set; }

    [JsonPropertyName("preview")]
    public bool? Preview { get; set; }

    [JsonPropertyName("remediationDescription")]
    public string? RemediationDescription { get; set; }

    [JsonPropertyName("severity")]
    [Required]
    public SeverityConstant Severity { get; set; }

    [JsonPropertyName("threats")]
    public List<ThreatsConstant>? Threats { get; set; }

    [JsonPropertyName("userImpact")]
    public UserImpactConstant? UserImpact { get; set; }
}
