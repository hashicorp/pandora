// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagementActionTenantDeploymentStatusModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("statuses")]
    public List<ManagementActionDeploymentStatusModel>? Statuses { get; set; }

    [JsonPropertyName("tenantGroupId")]
    public string? TenantGroupId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
