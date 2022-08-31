using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.BackupVaults;


internal class ResourceMoveDetailsModel
{
    [JsonPropertyName("completionTimeUtc")]
    public string? CompletionTimeUtc { get; set; }

    [JsonPropertyName("operationId")]
    public string? OperationId { get; set; }

    [JsonPropertyName("sourceResourcePath")]
    public string? SourceResourcePath { get; set; }

    [JsonPropertyName("startTimeUtc")]
    public string? StartTimeUtc { get; set; }

    [JsonPropertyName("targetResourcePath")]
    public string? TargetResourcePath { get; set; }
}
