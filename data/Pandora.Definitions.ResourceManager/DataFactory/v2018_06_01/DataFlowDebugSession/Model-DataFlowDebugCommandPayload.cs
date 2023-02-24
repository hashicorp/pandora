using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.DataFlowDebugSession;


internal class DataFlowDebugCommandPayloadModel
{
    [JsonPropertyName("columns")]
    public List<string>? Columns { get; set; }

    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

    [JsonPropertyName("rowLimits")]
    public int? RowLimits { get; set; }

    [JsonPropertyName("streamName")]
    [Required]
    public string StreamName { get; set; }
}
