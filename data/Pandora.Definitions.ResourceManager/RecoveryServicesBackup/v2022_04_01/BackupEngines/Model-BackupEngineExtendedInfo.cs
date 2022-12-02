using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.BackupEngines;


internal class BackupEngineExtendedInfoModel
{
    [JsonPropertyName("availableDiskSpace")]
    public float? AvailableDiskSpace { get; set; }

    [JsonPropertyName("azureProtectedInstances")]
    public int? AzureProtectedInstances { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("diskCount")]
    public int? DiskCount { get; set; }

    [JsonPropertyName("protectedItemsCount")]
    public int? ProtectedItemsCount { get; set; }

    [JsonPropertyName("protectedServersCount")]
    public int? ProtectedServersCount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("refreshedAt")]
    public DateTime? RefreshedAt { get; set; }

    [JsonPropertyName("usedDiskSpace")]
    public float? UsedDiskSpace { get; set; }
}
