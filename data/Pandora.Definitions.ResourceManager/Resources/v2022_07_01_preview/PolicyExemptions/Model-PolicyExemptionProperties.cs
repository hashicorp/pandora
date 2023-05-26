using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_07_01_preview.PolicyExemptions;


internal class PolicyExemptionPropertiesModel
{
    [JsonPropertyName("assignmentScopeValidation")]
    public AssignmentScopeValidationConstant? AssignmentScopeValidation { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("exemptionCategory")]
    [Required]
    public ExemptionCategoryConstant ExemptionCategory { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiresOn")]
    public DateTime? ExpiresOn { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }

    [JsonPropertyName("policyAssignmentId")]
    [Required]
    public string PolicyAssignmentId { get; set; }

    [JsonPropertyName("policyDefinitionReferenceIds")]
    public List<string>? PolicyDefinitionReferenceIds { get; set; }

    [JsonPropertyName("resourceSelectors")]
    public List<ResourceSelectorModel>? ResourceSelectors { get; set; }
}
