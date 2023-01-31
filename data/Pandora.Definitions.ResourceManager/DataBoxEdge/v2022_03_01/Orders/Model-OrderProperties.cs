using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Orders;


internal class OrderPropertiesModel
{
    [JsonPropertyName("contactInformation")]
    [Required]
    public ContactDetailsModel ContactInformation { get; set; }

    [JsonPropertyName("currentStatus")]
    public OrderStatusModel? CurrentStatus { get; set; }

    [JsonPropertyName("deliveryTrackingInfo")]
    public List<TrackingInfoModel>? DeliveryTrackingInfo { get; set; }

    [JsonPropertyName("orderHistory")]
    public List<OrderStatusModel>? OrderHistory { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("returnTrackingInfo")]
    public List<TrackingInfoModel>? ReturnTrackingInfo { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("shipmentType")]
    public ShipmentTypeConstant? ShipmentType { get; set; }

    [JsonPropertyName("shippingAddress")]
    public AddressModel? ShippingAddress { get; set; }
}
