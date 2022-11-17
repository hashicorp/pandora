using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2022_09_01.ContainerInstance;


internal class LogAnalyticsModel
{
    [JsonPropertyName("logType")]
    public LogAnalyticsLogTypeConstant? LogType { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonPropertyName("workspaceId")]
    [Required]
    public string WorkspaceId { get; set; }

    [JsonPropertyName("workspaceKey")]
    [Required]
    public string WorkspaceKey { get; set; }

    [JsonPropertyName("workspaceResourceId")]
    public string? WorkspaceResourceId { get; set; }
}
