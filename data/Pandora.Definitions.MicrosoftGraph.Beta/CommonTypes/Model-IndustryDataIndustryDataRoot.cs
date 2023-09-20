// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IndustryDataIndustryDataRootModel
{
    [JsonPropertyName("dataConnectors")]
    public List<IndustryDataIndustryDataConnectorModel>? DataConnectors { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inboundFlows")]
    public List<IndustryDataInboundFlowModel>? InboundFlows { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<LongRunningOperationModel>? Operations { get; set; }

    [JsonPropertyName("referenceDefinitions")]
    public List<IndustryDataReferenceDefinitionModel>? ReferenceDefinitions { get; set; }

    [JsonPropertyName("roleGroups")]
    public List<IndustryDataRoleGroupModel>? RoleGroups { get; set; }

    [JsonPropertyName("runs")]
    public List<IndustryDataIndustryDataRunModel>? Runs { get; set; }

    [JsonPropertyName("sourceSystems")]
    public List<IndustryDataSourceSystemDefinitionModel>? SourceSystems { get; set; }

    [JsonPropertyName("years")]
    public List<IndustryDataYearTimePeriodDefinitionModel>? Years { get; set; }
}
