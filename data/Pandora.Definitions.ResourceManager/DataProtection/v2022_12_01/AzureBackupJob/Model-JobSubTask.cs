using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.AzureBackupJob;


internal class JobSubTaskModel
{
    [JsonPropertyName("additionalDetails")]
    public Dictionary<string, string>? AdditionalDetails { get; set; }

    [JsonPropertyName("taskId")]
    [Required]
    public int TaskId { get; set; }

    [JsonPropertyName("taskName")]
    [Required]
    public string TaskName { get; set; }

    [JsonPropertyName("taskProgress")]
    public string? TaskProgress { get; set; }

    [JsonPropertyName("taskStatus")]
    [Required]
    public string TaskStatus { get; set; }
}
