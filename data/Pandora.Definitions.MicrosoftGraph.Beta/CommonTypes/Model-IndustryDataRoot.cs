// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IndustryDataRootModel
{
    [JsonPropertyName("dataConnectors")]
    public List<IndustryDataConnectorModel>? DataConnectors { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inboundFlows")]
    public List<InboundFlowModel>? InboundFlows { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<LongRunningOperationModel>? Operations { get; set; }

    [JsonPropertyName("referenceDefinitions")]
    public List<ReferenceDefinitionModel>? ReferenceDefinitions { get; set; }

    [JsonPropertyName("roleGroups")]
    public List<RoleGroupModel>? RoleGroups { get; set; }

    [JsonPropertyName("runs")]
    public List<IndustryDataRunModel>? Runs { get; set; }

    [JsonPropertyName("sourceSystems")]
    public List<SourceSystemDefinitionModel>? SourceSystems { get; set; }

    [JsonPropertyName("years")]
    public List<YearTimePeriodDefinitionModel>? Years { get; set; }
}
