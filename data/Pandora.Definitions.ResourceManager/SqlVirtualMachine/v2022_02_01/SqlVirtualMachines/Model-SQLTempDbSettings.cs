using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class SQLTempDbSettingsModel
{
    [JsonPropertyName("dataFileCount")]
    public int? DataFileCount { get; set; }

    [JsonPropertyName("dataFileSize")]
    public int? DataFileSize { get; set; }

    [JsonPropertyName("dataGrowth")]
    public int? DataGrowth { get; set; }

    [JsonPropertyName("defaultFilePath")]
    public string? DefaultFilePath { get; set; }

    [JsonPropertyName("logFileSize")]
    public int? LogFileSize { get; set; }

    [JsonPropertyName("logGrowth")]
    public int? LogGrowth { get; set; }

    [JsonPropertyName("luns")]
    public List<int>? Luns { get; set; }

    [JsonPropertyName("persistFolder")]
    public bool? PersistFolder { get; set; }

    [JsonPropertyName("persistFolderPath")]
    public string? PersistFolderPath { get; set; }
}
