using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsMaintenanceWindowOptions;


internal class MaintenanceWindowOptionsPropertiesModel
{
    [JsonPropertyName("allowMultipleMaintenanceWindowsPerCycle")]
    public bool? AllowMultipleMaintenanceWindowsPerCycle { get; set; }

    [JsonPropertyName("defaultDurationInMinutes")]
    public int? DefaultDurationInMinutes { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("maintenanceWindowCycles")]
    public List<MaintenanceWindowTimeRangeModel>? MaintenanceWindowCycles { get; set; }

    [JsonPropertyName("minCycles")]
    public int? MinCycles { get; set; }

    [JsonPropertyName("minDurationInMinutes")]
    public int? MinDurationInMinutes { get; set; }

    [JsonPropertyName("timeGranularityInMinutes")]
    public int? TimeGranularityInMinutes { get; set; }
}
