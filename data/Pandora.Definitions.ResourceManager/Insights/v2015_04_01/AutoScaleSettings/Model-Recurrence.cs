using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01.AutoScaleSettings;


internal class RecurrenceModel
{
    [JsonPropertyName("frequency")]
    [Required]
    public RecurrenceFrequencyConstant Frequency { get; set; }

    [JsonPropertyName("schedule")]
    [Required]
    public RecurrentScheduleModel Schedule { get; set; }
}
