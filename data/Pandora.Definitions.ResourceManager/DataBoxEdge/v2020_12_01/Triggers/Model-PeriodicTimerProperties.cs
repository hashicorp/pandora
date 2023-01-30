using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Triggers;


internal class PeriodicTimerPropertiesModel
{
    [JsonPropertyName("customContextTag")]
    public string? CustomContextTag { get; set; }

    [JsonPropertyName("sinkInfo")]
    [Required]
    public RoleSinkInfoModel SinkInfo { get; set; }

    [JsonPropertyName("sourceInfo")]
    [Required]
    public PeriodicTimerSourceInfoModel SourceInfo { get; set; }
}
