using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.IoTCentral.v2021_11_01_preview.Apps;


internal class NetworkRuleSetsModel
{
    [JsonPropertyName("applyToDevices")]
    public bool? ApplyToDevices { get; set; }

    [JsonPropertyName("applyToIoTCentral")]
    public bool? ApplyToIoTCentral { get; set; }

    [JsonPropertyName("defaultAction")]
    public NetworkActionConstant? DefaultAction { get; set; }

    [JsonPropertyName("ipRules")]
    public List<NetworkRuleSetIPRuleModel>? IPRules { get; set; }
}
