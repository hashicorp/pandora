using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.DataFlowDebugSession;


internal class DataFlowDebugPackageDebugSettingsModel
{
    [JsonPropertyName("datasetParameters")]
    public object? DatasetParameters { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, object>? Parameters { get; set; }

    [JsonPropertyName("sourceSettings")]
    public List<DataFlowSourceSettingModel>? SourceSettings { get; set; }
}
