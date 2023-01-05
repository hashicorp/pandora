using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.Configurations;


internal class ConfigurationPropertiesModel
{
    [JsonPropertyName("allowedValues")]
    public string? AllowedValues { get; set; }

    [JsonPropertyName("dataType")]
    public string? DataType { get; set; }

    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("isConfigPendingRestart")]
    public IsConfigPendingRestartConstant? IsConfigPendingRestart { get; set; }

    [JsonPropertyName("isDynamicConfig")]
    public IsDynamicConfigConstant? IsDynamicConfig { get; set; }

    [JsonPropertyName("isReadOnly")]
    public IsReadOnlyConstant? IsReadOnly { get; set; }

    [JsonPropertyName("source")]
    public ConfigurationSourceConstant? Source { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
