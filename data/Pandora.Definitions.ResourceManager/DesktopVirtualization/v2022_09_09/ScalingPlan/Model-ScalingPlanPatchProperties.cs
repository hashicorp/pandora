using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.ScalingPlan;


internal class ScalingPlanPatchPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("exclusionTag")]
    public string? ExclusionTag { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("hostPoolReferences")]
    public List<ScalingHostPoolReferenceModel>? HostPoolReferences { get; set; }

    [JsonPropertyName("schedules")]
    public List<ScalingScheduleModel>? Schedules { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }
}
