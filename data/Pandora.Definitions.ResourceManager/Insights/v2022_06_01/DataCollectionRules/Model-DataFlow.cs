using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;


internal class DataFlowModel
{
    [JsonPropertyName("builtInTransform")]
    public string? BuiltInTransform { get; set; }

    [JsonPropertyName("destinations")]
    public List<string>? Destinations { get; set; }

    [JsonPropertyName("outputStream")]
    public string? OutputStream { get; set; }

    [JsonPropertyName("streams")]
    public List<KnownDataFlowStreamsConstant>? Streams { get; set; }

    [JsonPropertyName("transformKql")]
    public string? TransformKql { get; set; }
}
