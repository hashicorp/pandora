using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.DatabaseRecommendedActions;


internal class RecommendedActionImpactRecordModel
{
    [JsonPropertyName("absoluteValue")]
    public float? AbsoluteValue { get; set; }

    [JsonPropertyName("changeValueAbsolute")]
    public float? ChangeValueAbsolute { get; set; }

    [JsonPropertyName("changeValueRelative")]
    public float? ChangeValueRelative { get; set; }

    [JsonPropertyName("dimensionName")]
    public string? DimensionName { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
