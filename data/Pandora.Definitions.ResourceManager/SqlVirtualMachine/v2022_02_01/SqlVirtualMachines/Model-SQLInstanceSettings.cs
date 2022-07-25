using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class SQLInstanceSettingsModel
{
    [JsonPropertyName("collation")]
    public string? Collation { get; set; }

    [JsonPropertyName("isIfiEnabled")]
    public bool? IsIfiEnabled { get; set; }

    [JsonPropertyName("isLpimEnabled")]
    public bool? IsLpimEnabled { get; set; }

    [JsonPropertyName("isOptimizeForAdHocWorkloadsEnabled")]
    public bool? IsOptimizeForAdHocWorkloadsEnabled { get; set; }

    [JsonPropertyName("maxDop")]
    public int? MaxDop { get; set; }

    [JsonPropertyName("maxServerMemoryMB")]
    public int? MaxServerMemoryMB { get; set; }

    [JsonPropertyName("minServerMemoryMB")]
    public int? MinServerMemoryMB { get; set; }
}
