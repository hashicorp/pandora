// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedAccessModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resources")]
    public List<GovernanceResourceModel>? Resources { get; set; }

    [JsonPropertyName("roleAssignmentRequests")]
    public List<GovernanceRoleAssignmentRequestModel>? RoleAssignmentRequests { get; set; }

    [JsonPropertyName("roleAssignments")]
    public List<GovernanceRoleAssignmentModel>? RoleAssignments { get; set; }

    [JsonPropertyName("roleDefinitions")]
    public List<GovernanceRoleDefinitionModel>? RoleDefinitions { get; set; }

    [JsonPropertyName("roleSettings")]
    public List<GovernanceRoleSettingModel>? RoleSettings { get; set; }
}
