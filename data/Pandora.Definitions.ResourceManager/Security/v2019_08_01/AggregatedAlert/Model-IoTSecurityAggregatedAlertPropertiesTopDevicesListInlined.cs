using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.AggregatedAlert;


internal class IoTSecurityAggregatedAlertPropertiesTopDevicesListInlinedModel
{
    [JsonPropertyName("alertsCount")]
    public int? AlertsCount { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("lastOccurrence")]
    public string? LastOccurrence { get; set; }
}
