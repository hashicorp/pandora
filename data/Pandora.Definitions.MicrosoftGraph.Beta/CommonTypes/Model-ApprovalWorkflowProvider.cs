// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ApprovalWorkflowProviderModel
{
    [JsonPropertyName("businessFlows")]
    public List<BusinessFlowModel>? BusinessFlows { get; set; }

    [JsonPropertyName("businessFlowsWithRequestsAwaitingMyDecision")]
    public List<BusinessFlowModel>? BusinessFlowsWithRequestsAwaitingMyDecision { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyTemplates")]
    public List<GovernancePolicyTemplateModel>? PolicyTemplates { get; set; }
}
