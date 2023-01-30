using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Addons;


internal class IoTDeviceInfoModel
{
    [JsonPropertyName("authentication")]
    public AuthenticationModel? Authentication { get; set; }

    [JsonPropertyName("deviceId")]
    [Required]
    public string DeviceId { get; set; }

    [JsonPropertyName("ioTHostHub")]
    [Required]
    public string IoTHostHub { get; set; }

    [JsonPropertyName("ioTHostHubId")]
    public string? IoTHostHubId { get; set; }
}
