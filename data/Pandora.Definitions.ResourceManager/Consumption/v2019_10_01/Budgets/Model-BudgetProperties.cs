using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Budgets;


internal class BudgetPropertiesModel
{
    [JsonPropertyName("amount")]
    [Required]
    public float Amount { get; set; }

    [JsonPropertyName("category")]
    [Required]
    public CategoryTypeConstant Category { get; set; }

    [JsonPropertyName("currentSpend")]
    public CurrentSpendModel? CurrentSpend { get; set; }

    [JsonPropertyName("filter")]
    public BudgetFilterModel? Filter { get; set; }

    [JsonPropertyName("forecastSpend")]
    public ForecastSpendModel? ForecastSpend { get; set; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, NotificationModel>? Notifications { get; set; }

    [JsonPropertyName("timeGrain")]
    [Required]
    public TimeGrainTypeConstant TimeGrain { get; set; }

    [JsonPropertyName("timePeriod")]
    [Required]
    public BudgetTimePeriodModel TimePeriod { get; set; }
}
