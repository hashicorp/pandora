// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationPolicyTemplateReferenceModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("templateDisplayName")]
    public string? TemplateDisplayName { get; set; }

    [JsonPropertyName("templateDisplayVersion")]
    public string? TemplateDisplayVersion { get; set; }

    [JsonPropertyName("templateFamily")]
    public DeviceManagementConfigurationTemplateFamilyConstant? TemplateFamily { get; set; }

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; set; }
}
