using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServicePlans;


internal class HybridConnectionPropertiesModel
{
    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("relayArmUri")]
    public string? RelayArmUri { get; set; }

    [JsonPropertyName("relayName")]
    public string? RelayName { get; set; }

    [JsonPropertyName("sendKeyName")]
    public string? SendKeyName { get; set; }

    [JsonPropertyName("sendKeyValue")]
    public string? SendKeyValue { get; set; }

    [JsonPropertyName("serviceBusNamespace")]
    public string? ServiceBusNamespace { get; set; }

    [JsonPropertyName("serviceBusSuffix")]
    public string? ServiceBusSuffix { get; set; }
}
