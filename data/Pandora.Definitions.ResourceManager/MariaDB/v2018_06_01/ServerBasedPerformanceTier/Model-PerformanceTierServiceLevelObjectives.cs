using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.ServerBasedPerformanceTier;


internal class PerformanceTierServiceLevelObjectivesModel
{
    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("hardwareGeneration")]
    public string? HardwareGeneration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("maxBackupRetentionDays")]
    public int? MaxBackupRetentionDays { get; set; }

    [JsonPropertyName("maxStorageMB")]
    public int? MaxStorageMB { get; set; }

    [JsonPropertyName("minBackupRetentionDays")]
    public int? MinBackupRetentionDays { get; set; }

    [JsonPropertyName("minStorageMB")]
    public int? MinStorageMB { get; set; }

    [JsonPropertyName("vCore")]
    public int? VCore { get; set; }
}
