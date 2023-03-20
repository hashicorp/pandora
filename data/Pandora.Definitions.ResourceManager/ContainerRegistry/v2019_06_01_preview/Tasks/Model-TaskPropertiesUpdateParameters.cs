using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;


internal class TaskPropertiesUpdateParametersModel
{
    [JsonPropertyName("agentConfiguration")]
    public AgentPropertiesModel? AgentConfiguration { get; set; }

    [JsonPropertyName("agentPoolName")]
    public string? AgentPoolName { get; set; }

    [JsonPropertyName("credentials")]
    public CredentialsModel? Credentials { get; set; }

    [JsonPropertyName("logTemplate")]
    public string? LogTemplate { get; set; }

    [JsonPropertyName("platform")]
    public PlatformUpdateParametersModel? Platform { get; set; }

    [JsonPropertyName("status")]
    public TaskStatusConstant? Status { get; set; }

    [JsonPropertyName("step")]
    public TaskStepUpdateParametersModel? Step { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("trigger")]
    public TriggerUpdateParametersModel? Trigger { get; set; }
}
