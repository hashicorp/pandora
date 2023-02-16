using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.LocationBasedPerformanceTier;


internal class PerformanceTierPropertiesModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("maxBackupRetentionDays")]
    public int? MaxBackupRetentionDays { get; set; }

    [JsonPropertyName("maxLargeStorageMB")]
    public int? MaxLargeStorageMB { get; set; }

    [JsonPropertyName("maxStorageMB")]
    public int? MaxStorageMB { get; set; }

    [JsonPropertyName("minBackupRetentionDays")]
    public int? MinBackupRetentionDays { get; set; }

    [JsonPropertyName("minLargeStorageMB")]
    public int? MinLargeStorageMB { get; set; }

    [JsonPropertyName("minStorageMB")]
    public int? MinStorageMB { get; set; }

    [JsonPropertyName("serviceLevelObjectives")]
    public List<PerformanceTierServiceLevelObjectivesModel>? ServiceLevelObjectives { get; set; }
}
