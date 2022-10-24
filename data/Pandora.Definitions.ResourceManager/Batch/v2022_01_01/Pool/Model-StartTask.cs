using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Pool;


internal class StartTaskModel
{
    [JsonPropertyName("commandLine")]
    public string? CommandLine { get; set; }

    [JsonPropertyName("containerSettings")]
    public TaskContainerSettingsModel? ContainerSettings { get; set; }

    [JsonPropertyName("environmentSettings")]
    public List<EnvironmentSettingModel>? EnvironmentSettings { get; set; }

    [JsonPropertyName("maxTaskRetryCount")]
    public int? MaxTaskRetryCount { get; set; }

    [JsonPropertyName("resourceFiles")]
    public List<ResourceFileModel>? ResourceFiles { get; set; }

    [JsonPropertyName("userIdentity")]
    public UserIdentityModel? UserIdentity { get; set; }

    [JsonPropertyName("waitForSuccess")]
    public bool? WaitForSuccess { get; set; }
}
