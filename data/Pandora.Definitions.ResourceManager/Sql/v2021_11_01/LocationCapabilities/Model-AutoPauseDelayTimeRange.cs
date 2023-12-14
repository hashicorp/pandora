using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.LocationCapabilities;


internal class AutoPauseDelayTimeRangeModel
{
    [JsonPropertyName("default")]
    public int? Default { get; set; }

    [JsonPropertyName("doNotPauseValue")]
    public int? DoNotPauseValue { get; set; }

    [JsonPropertyName("maxValue")]
    public int? MaxValue { get; set; }

    [JsonPropertyName("minValue")]
    public int? MinValue { get; set; }

    [JsonPropertyName("stepSize")]
    public int? StepSize { get; set; }

    [JsonPropertyName("unit")]
    public PauseDelayTimeUnitConstant? Unit { get; set; }
}
