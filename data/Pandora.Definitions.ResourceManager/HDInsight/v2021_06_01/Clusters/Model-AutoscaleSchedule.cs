using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Clusters;


internal class AutoscaleScheduleModel
{
    [JsonPropertyName("days")]
    public List<DaysOfWeekConstant>? Days { get; set; }

    [JsonPropertyName("timeAndCapacity")]
    public AutoscaleTimeAndCapacityModel? TimeAndCapacity { get; set; }
}
