using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Watcher;


internal class WatcherPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("executionFrequencyInSeconds")]
    public int? ExecutionFrequencyInSeconds { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("scriptName")]
    public string? ScriptName { get; set; }

    [JsonPropertyName("scriptParameters")]
    public Dictionary<string, string>? ScriptParameters { get; set; }

    [JsonPropertyName("scriptRunOn")]
    public string? ScriptRunOn { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
