using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedInstanceLongTermRetentionPolicies;


internal class BaseLongTermRetentionPolicyPropertiesModel
{
    [JsonPropertyName("monthlyRetention")]
    public string? MonthlyRetention { get; set; }

    [JsonPropertyName("weekOfYear")]
    public int? WeekOfYear { get; set; }

    [JsonPropertyName("weeklyRetention")]
    public string? WeeklyRetention { get; set; }

    [JsonPropertyName("yearlyRetention")]
    public string? YearlyRetention { get; set; }
}
