using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2020_05_01.ManagementGroups;


internal class ManagementGroupPropertiesModel
{
    [JsonPropertyName("children")]
    public List<ManagementGroupChildInfoModel>? Children { get; set; }

    [JsonPropertyName("details")]
    public ManagementGroupDetailsModel? Details { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
