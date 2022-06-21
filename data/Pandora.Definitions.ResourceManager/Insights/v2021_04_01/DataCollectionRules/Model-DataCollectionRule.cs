using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;


internal class DataCollectionRuleModel
{
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

    [JsonPropertyName("provisioningState")]
    public KnownDataCollectionRuleProvisioningStateConstant? ProvisioningState { get; set; }
}
