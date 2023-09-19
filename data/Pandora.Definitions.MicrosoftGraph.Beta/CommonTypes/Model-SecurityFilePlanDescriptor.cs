// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityFilePlanDescriptorModel
{
    [JsonPropertyName("authority")]
    public SecurityAuthorityModel? Authority { get; set; }

    [JsonPropertyName("authorityTemplate")]
    public SecurityAuthorityTemplateModel? AuthorityTemplate { get; set; }

    [JsonPropertyName("category")]
    public SecurityAppliedCategoryModel? Category { get; set; }

    [JsonPropertyName("categoryTemplate")]
    public SecurityCategoryTemplateModel? CategoryTemplate { get; set; }

    [JsonPropertyName("citation")]
    public SecurityCitationModel? Citation { get; set; }

    [JsonPropertyName("citationTemplate")]
    public SecurityCitationTemplateModel? CitationTemplate { get; set; }

    [JsonPropertyName("department")]
    public SecurityDepartmentModel? Department { get; set; }

    [JsonPropertyName("departmentTemplate")]
    public SecurityDepartmentTemplateModel? DepartmentTemplate { get; set; }

    [JsonPropertyName("filePlanReference")]
    public SecurityFilePlanReferenceModel? FilePlanReference { get; set; }

    [JsonPropertyName("filePlanReferenceTemplate")]
    public SecurityFilePlanReferenceTemplateModel? FilePlanReferenceTemplate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
