// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PositiveReinforcementNotificationModel
{
    [JsonPropertyName("defaultLanguage")]
    public string? DefaultLanguage { get; set; }

    [JsonPropertyName("deliveryPreference")]
    public PositiveReinforcementNotificationDeliveryPreferenceConstant? DeliveryPreference { get; set; }

    [JsonPropertyName("endUserNotification")]
    public EndUserNotificationModel? EndUserNotification { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
