// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TenantGroupModel
{
    [JsonPropertyName("allTenantsIncluded")]
    public bool? AllTenantsIncluded { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managementActions")]
    public List<ManagementActionInfoModel>? ManagementActions { get; set; }

    [JsonPropertyName("managementIntents")]
    public List<ManagementIntentInfoModel>? ManagementIntents { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantIds")]
    public List<string>? TenantIds { get; set; }
}
