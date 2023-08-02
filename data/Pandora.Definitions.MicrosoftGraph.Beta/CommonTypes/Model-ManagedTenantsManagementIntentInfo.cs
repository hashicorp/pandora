// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagementIntentInfoModel
{
    [JsonPropertyName("managementIntentDisplayName")]
    public string? ManagementIntentDisplayName { get; set; }

    [JsonPropertyName("managementIntentId")]
    public string? ManagementIntentId { get; set; }

    [JsonPropertyName("managementTemplates")]
    public List<ManagementTemplateDetailedInfoModel>? ManagementTemplates { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
