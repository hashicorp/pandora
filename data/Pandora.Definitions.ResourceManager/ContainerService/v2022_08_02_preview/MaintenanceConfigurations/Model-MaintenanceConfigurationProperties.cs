using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.MaintenanceConfigurations;


internal class MaintenanceConfigurationPropertiesModel
{
    [JsonPropertyName("notAllowedTime")]
    public List<TimeSpanModel>? NotAllowedTime { get; set; }

    [JsonPropertyName("timeInWeek")]
    public List<TimeInWeekModel>? TimeInWeek { get; set; }
}
