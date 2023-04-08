using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityAlerts;


internal class IotAlertPropertiesModel
{
    [JsonPropertyName("alertType")]
    public string? AlertType { get; set; }

    [JsonPropertyName("compromisedEntity")]
    public string? CompromisedEntity { get; set; }

    [JsonPropertyName("endTimeUtc")]
    public string? EndTimeUtc { get; set; }

    [JsonPropertyName("entities")]
    public List<object>? Entities { get; set; }

    [JsonPropertyName("extendedProperties")]
    public object? ExtendedProperties { get; set; }

    [JsonPropertyName("startTimeUtc")]
    public string? StartTimeUtc { get; set; }

    [JsonPropertyName("systemAlertId")]
    public string? SystemAlertId { get; set; }
}
