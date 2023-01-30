using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Orders;


internal class OrderStatusModel
{
    [JsonPropertyName("additionalOrderDetails")]
    public Dictionary<string, string>? AdditionalOrderDetails { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public OrderStateConstant Status { get; set; }

    [JsonPropertyName("trackingInformation")]
    public TrackingInfoModel? TrackingInformation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updateDateTime")]
    public DateTime? UpdateDateTime { get; set; }
}
