using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;


internal class DataCollectionRuleModel
{
    [JsonPropertyName("dataCollectionEndpointId")]
    public string? DataCollectionEndpointId { get; set; }

    [JsonPropertyName("dataFlows")]
    public List<DataFlowModel>? DataFlows { get; set; }

    [JsonPropertyName("dataSources")]
    public DataSourcesSpecModel? DataSources { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destinations")]
    public DestinationsSpecModel? Destinations { get; set; }

    [JsonPropertyName("immutableId")]
    public string? ImmutableId { get; set; }

    [JsonPropertyName("metadata")]
    public MetadataModel? Metadata { get; set; }

    [JsonPropertyName("provisioningState")]
    public KnownDataCollectionRuleProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("streamDeclarations")]
    public Dictionary<string, StreamDeclarationModel>? StreamDeclarations { get; set; }
}
