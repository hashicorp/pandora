// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesAgentModel
{
    [JsonPropertyName("agentGroups")]
    public List<OnPremisesAgentGroupModel>? AgentGroups { get; set; }

    [JsonPropertyName("externalIp")]
    public string? ExternalIp { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public AgentStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedPublishingTypes")]
    public List<OnPremisesPublishingTypeConstant>? SupportedPublishingTypes { get; set; }
}
