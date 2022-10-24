using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.SourceControls;


internal class RepositoryModel
{
    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("deploymentLogsUrl")]
    public string? DeploymentLogsUrl { get; set; }

    [JsonPropertyName("displayUrl")]
    public string? DisplayUrl { get; set; }

    [JsonPropertyName("pathMapping")]
    public List<ContentPathMapModel>? PathMapping { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
