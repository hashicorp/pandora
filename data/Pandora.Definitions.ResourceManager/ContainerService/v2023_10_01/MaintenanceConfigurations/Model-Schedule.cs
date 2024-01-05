using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.MaintenanceConfigurations;


internal class ScheduleModel
{
    [JsonPropertyName("absoluteMonthly")]
    public AbsoluteMonthlyScheduleModel? AbsoluteMonthly { get; set; }

    [JsonPropertyName("daily")]
    public DailyScheduleModel? Daily { get; set; }

    [JsonPropertyName("relativeMonthly")]
    public RelativeMonthlyScheduleModel? RelativeMonthly { get; set; }

    [JsonPropertyName("weekly")]
    public WeeklyScheduleModel? Weekly { get; set; }
}
