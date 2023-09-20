// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityLabelsRootModel
{
    [JsonPropertyName("authorities")]
    public List<SecurityAuthorityTemplateModel>? Authorities { get; set; }

    [JsonPropertyName("categories")]
    public List<SecurityCategoryTemplateModel>? Categories { get; set; }

    [JsonPropertyName("citations")]
    public List<SecurityCitationTemplateModel>? Citations { get; set; }

    [JsonPropertyName("departments")]
    public List<SecurityDepartmentTemplateModel>? Departments { get; set; }

    [JsonPropertyName("filePlanReferences")]
    public List<SecurityFilePlanReferenceTemplateModel>? FilePlanReferences { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("retentionLabels")]
    public List<SecurityRetentionLabelModel>? RetentionLabels { get; set; }
}
