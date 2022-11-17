using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.CosmosDB;


internal class PeriodicModePropertiesModel
{
    [JsonPropertyName("backupIntervalInMinutes")]
    public int? BackupIntervalInMinutes { get; set; }

    [JsonPropertyName("backupRetentionIntervalInHours")]
    public int? BackupRetentionIntervalInHours { get; set; }

    [JsonPropertyName("backupStorageRedundancy")]
    public BackupStorageRedundancyConstant? BackupStorageRedundancy { get; set; }
}
