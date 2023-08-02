// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AppConfigurationSettingItemModel
{
    [JsonPropertyName("appConfigKey")]
    public string? AppConfigKey { get; set; }

    [JsonPropertyName("appConfigKeyType")]
    public MdmAppConfigKeyTypeConstant? AppConfigKeyType { get; set; }

    [JsonPropertyName("appConfigKeyValue")]
    public string? AppConfigKeyValue { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
