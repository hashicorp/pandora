// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IdentityGovernanceLifecycleWorkflowsContainerModel
{
    [JsonPropertyName("customTaskExtensions")]
    public List<IdentityGovernanceCustomTaskExtensionModel>? CustomTaskExtensions { get; set; }

    [JsonPropertyName("deletedItems")]
    public DeletedItemContainerModel? DeletedItems { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settings")]
    public IdentityGovernanceLifecycleManagementSettingsModel? Settings { get; set; }

    [JsonPropertyName("taskDefinitions")]
    public List<IdentityGovernanceTaskDefinitionModel>? TaskDefinitions { get; set; }

    [JsonPropertyName("workflowTemplates")]
    public List<IdentityGovernanceWorkflowTemplateModel>? WorkflowTemplates { get; set; }

    [JsonPropertyName("workflows")]
    public List<IdentityGovernanceWorkflowModel>? Workflows { get; set; }
}
