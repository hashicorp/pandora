using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.Assessments;


internal class SecurityAssessmentPropertiesModel
{
    [JsonPropertyName("additionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("links")]
    public AssessmentLinksModel? Links { get; set; }

    [JsonPropertyName("metadata")]
    public SecurityAssessmentMetadataPropertiesModel? Metadata { get; set; }

    [JsonPropertyName("partnersData")]
    public SecurityAssessmentPartnerDataModel? PartnersData { get; set; }

    [JsonPropertyName("resourceDetails")]
    [Required]
    public ResourceDetailsModel ResourceDetails { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public AssessmentStatusModel Status { get; set; }
}
