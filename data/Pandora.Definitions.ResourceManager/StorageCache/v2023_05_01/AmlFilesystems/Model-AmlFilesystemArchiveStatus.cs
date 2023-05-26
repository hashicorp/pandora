using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;


internal class AmlFilesystemArchiveStatusModel
{
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastCompletionTime")]
    public DateTime? LastCompletionTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStartedTime")]
    public DateTime? LastStartedTime { get; set; }

    [JsonPropertyName("percentComplete")]
    public int? PercentComplete { get; set; }

    [JsonPropertyName("state")]
    public ArchiveStatusTypeConstant? State { get; set; }
}
