using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.RecoverableServers;


internal class RecoverableServerPropertiesModel
{
    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("hardwareGeneration")]
    public string? HardwareGeneration { get; set; }

    [JsonPropertyName("lastAvailableBackupDateTime")]
    public string? LastAvailableBackupDateTime { get; set; }

    [JsonPropertyName("serviceLevelObjective")]
    public string? ServiceLevelObjective { get; set; }

    [JsonPropertyName("vCore")]
    public int? VCore { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
