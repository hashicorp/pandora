// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AwsExternalSystemAccessRoleFindingModel
{
    [JsonPropertyName("accessibleSystemIds")]
    public List<string>? AccessibleSystemIds { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissionsCreepIndex")]
    public PermissionsCreepIndexModel? PermissionsCreepIndex { get; set; }

    [JsonPropertyName("role")]
    public AwsRoleModel? Role { get; set; }
}
