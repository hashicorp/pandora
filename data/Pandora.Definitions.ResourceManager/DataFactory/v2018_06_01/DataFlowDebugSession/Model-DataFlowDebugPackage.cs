using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.DataFlowDebugSession;


internal class DataFlowDebugPackageModel
{
    [JsonPropertyName("dataFlow")]
    public DataFlowDebugResourceModel? DataFlow { get; set; }

    [JsonPropertyName("dataFlows")]
    public List<DataFlowDebugResourceModel>? DataFlows { get; set; }

    [JsonPropertyName("datasets")]
    public List<DatasetDebugResourceModel>? Datasets { get; set; }

    [JsonPropertyName("debugSettings")]
    public DataFlowDebugPackageDebugSettingsModel? DebugSettings { get; set; }

    [JsonPropertyName("linkedServices")]
    public List<LinkedServiceDebugResourceModel>? LinkedServices { get; set; }

    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    [JsonPropertyName("staging")]
    public DataFlowStagingInfoModel? Staging { get; set; }
}
