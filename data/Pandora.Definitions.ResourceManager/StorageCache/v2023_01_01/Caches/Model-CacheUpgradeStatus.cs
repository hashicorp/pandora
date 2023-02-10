using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;


internal class CacheUpgradeStatusModel
{
    [JsonPropertyName("currentFirmwareVersion")]
    public string? CurrentFirmwareVersion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("firmwareUpdateDeadline")]
    public DateTime? FirmwareUpdateDeadline { get; set; }

    [JsonPropertyName("firmwareUpdateStatus")]
    public FirmwareStatusTypeConstant? FirmwareUpdateStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastFirmwareUpdate")]
    public DateTime? LastFirmwareUpdate { get; set; }

    [JsonPropertyName("pendingFirmwareVersion")]
    public string? PendingFirmwareVersion { get; set; }
}
