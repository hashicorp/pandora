using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Costs;


internal class CostThresholdPropertiesModel
{
    [JsonPropertyName("displayOnChart")]
    public CostThresholdStatusConstant? DisplayOnChart { get; set; }

    [JsonPropertyName("notificationSent")]
    public string? NotificationSent { get; set; }

    [JsonPropertyName("percentageThreshold")]
    public PercentageCostThresholdPropertiesModel? PercentageThreshold { get; set; }

    [JsonPropertyName("sendNotificationWhenExceeded")]
    public CostThresholdStatusConstant? SendNotificationWhenExceeded { get; set; }

    [JsonPropertyName("thresholdId")]
    public string? ThresholdId { get; set; }
}
