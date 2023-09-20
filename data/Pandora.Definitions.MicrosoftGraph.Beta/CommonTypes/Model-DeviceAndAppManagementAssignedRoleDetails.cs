// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceAndAppManagementAssignedRoleDetailsModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleAssignmentIds")]
    public List<string>? RoleAssignmentIds { get; set; }

    [JsonPropertyName("roleDefinitionIds")]
    public List<string>? RoleDefinitionIds { get; set; }
}
