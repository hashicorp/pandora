using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Orders;


internal class TrackingInfoModel
{
    [JsonPropertyName("carrierName")]
    public string? CarrierName { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("trackingId")]
    public string? TrackingId { get; set; }

    [JsonPropertyName("trackingUrl")]
    public string? TrackingUrl { get; set; }
}
