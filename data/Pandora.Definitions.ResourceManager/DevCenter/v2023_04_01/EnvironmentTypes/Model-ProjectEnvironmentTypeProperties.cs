using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.EnvironmentTypes;


internal class ProjectEnvironmentTypePropertiesModel
{
    [JsonPropertyName("creatorRoleAssignment")]
    public ProjectEnvironmentTypeUpdatePropertiesCreatorRoleAssignmentModel? CreatorRoleAssignment { get; set; }

    [JsonPropertyName("deploymentTargetId")]
    public string? DeploymentTargetId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public EnvironmentTypeEnableStatusConstant? Status { get; set; }

    [JsonPropertyName("userRoleAssignments")]
    public Dictionary<string, UserRoleAssignmentModel>? UserRoleAssignments { get; set; }
}
