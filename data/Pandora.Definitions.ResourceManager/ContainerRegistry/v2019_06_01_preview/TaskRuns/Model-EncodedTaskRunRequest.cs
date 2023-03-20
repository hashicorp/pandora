using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.TaskRuns;

[ValueForType("EncodedTaskRunRequest")]
internal class EncodedTaskRunRequestModel : RunRequestModel
{
    [JsonPropertyName("agentConfiguration")]
    public AgentPropertiesModel? AgentConfiguration { get; set; }

    [JsonPropertyName("credentials")]
    public CredentialsModel? Credentials { get; set; }

    [JsonPropertyName("encodedTaskContent")]
    [Required]
    public string EncodedTaskContent { get; set; }

    [JsonPropertyName("encodedValuesContent")]
    public string? EncodedValuesContent { get; set; }

    [JsonPropertyName("platform")]
    [Required]
    public PlatformPropertiesModel Platform { get; set; }

    [JsonPropertyName("sourceLocation")]
    public string? SourceLocation { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("values")]
    public List<SetValueModel>? Values { get; set; }
}
