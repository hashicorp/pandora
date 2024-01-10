// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RegistryKeyStateModel
{
    [JsonPropertyName("hive")]
    public RegistryKeyStateHiveConstant? Hive { get; set; }

    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oldKey")]
    public string? OldKey { get; set; }

    [JsonPropertyName("oldValueData")]
    public string? OldValueData { get; set; }

    [JsonPropertyName("oldValueName")]
    public string? OldValueName { get; set; }

    [JsonPropertyName("operation")]
    public RegistryKeyStateOperationConstant? Operation { get; set; }

    [JsonPropertyName("processId")]
    public int? ProcessId { get; set; }

    [JsonPropertyName("valueData")]
    public string? ValueData { get; set; }

    [JsonPropertyName("valueName")]
    public string? ValueName { get; set; }

    [JsonPropertyName("valueType")]
    public RegistryKeyStateValueTypeConstant? ValueType { get; set; }
}
