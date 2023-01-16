using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Costs;


internal class LabCostDetailsPropertiesModel
{
    [JsonPropertyName("cost")]
    public float? Cost { get; set; }

    [JsonPropertyName("costType")]
    public CostTypeConstant? CostType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }
}
