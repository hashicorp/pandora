using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Costs;


internal class TargetCostPropertiesModel
{
    [JsonPropertyName("costThresholds")]
    public List<CostThresholdPropertiesModel>? CostThresholds { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("cycleEndDateTime")]
    public DateTime? CycleEndDateTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("cycleStartDateTime")]
    public DateTime? CycleStartDateTime { get; set; }

    [JsonPropertyName("cycleType")]
    public ReportingCycleTypeConstant? CycleType { get; set; }

    [JsonPropertyName("status")]
    public TargetCostStatusConstant? Status { get; set; }

    [JsonPropertyName("target")]
    public int? Target { get; set; }
}
