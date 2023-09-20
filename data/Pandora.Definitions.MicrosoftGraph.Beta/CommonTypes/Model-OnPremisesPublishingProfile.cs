// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesPublishingProfileModel
{
    [JsonPropertyName("agentGroups")]
    public List<OnPremisesAgentGroupModel>? AgentGroups { get; set; }

    [JsonPropertyName("agents")]
    public List<OnPremisesAgentModel>? Agents { get; set; }

    [JsonPropertyName("connectorGroups")]
    public List<ConnectorGroupModel>? ConnectorGroups { get; set; }

    [JsonPropertyName("connectors")]
    public List<ConnectorModel>? Connectors { get; set; }

    [JsonPropertyName("hybridAgentUpdaterConfiguration")]
    public HybridAgentUpdaterConfigurationModel? HybridAgentUpdaterConfiguration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefaultAccessEnabled")]
    public bool? IsDefaultAccessEnabled { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publishedResources")]
    public List<PublishedResourceModel>? PublishedResources { get; set; }
}
