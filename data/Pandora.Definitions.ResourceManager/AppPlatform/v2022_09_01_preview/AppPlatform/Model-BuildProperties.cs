using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;


internal class BuildPropertiesModel
{
    [JsonPropertyName("agentPool")]
    public string? AgentPool { get; set; }

    [JsonPropertyName("builder")]
    public string? Builder { get; set; }

    [JsonPropertyName("env")]
    public Dictionary<string, string>? Env { get; set; }

    [JsonPropertyName("provisioningState")]
    public BuildProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("relativePath")]
    public string? RelativePath { get; set; }

    [JsonPropertyName("resourceRequests")]
    public BuildResourceRequestsModel? ResourceRequests { get; set; }

    [JsonPropertyName("triggeredBuildResult")]
    public TriggeredBuildResultModel? TriggeredBuildResult { get; set; }
}
