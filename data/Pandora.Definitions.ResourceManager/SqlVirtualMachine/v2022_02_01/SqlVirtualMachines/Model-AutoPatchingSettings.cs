using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class AutoPatchingSettingsModel
{
    [JsonPropertyName("dayOfWeek")]
    public DayOfWeekConstant? DayOfWeek { get; set; }

    [JsonPropertyName("enable")]
    public bool? Enable { get; set; }

    [JsonPropertyName("maintenanceWindowDuration")]
    public int? MaintenanceWindowDuration { get; set; }

    [JsonPropertyName("maintenanceWindowStartingHour")]
    public int? MaintenanceWindowStartingHour { get; set; }
}
