using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;


internal class TaskPropertiesModel
{
    [JsonPropertyName("agentConfiguration")]
    public AgentPropertiesModel? AgentConfiguration { get; set; }

    [JsonPropertyName("agentPoolName")]
    public string? AgentPoolName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("credentials")]
    public CredentialsModel? Credentials { get; set; }

    [JsonPropertyName("isSystemTask")]
    public bool? IsSystemTask { get; set; }

    [JsonPropertyName("logTemplate")]
    public string? LogTemplate { get; set; }

    [JsonPropertyName("platform")]
    public PlatformPropertiesModel? Platform { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public TaskStatusConstant? Status { get; set; }

    [JsonPropertyName("step")]
    public TaskStepPropertiesModel? Step { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("trigger")]
    public TriggerPropertiesModel? Trigger { get; set; }
}
