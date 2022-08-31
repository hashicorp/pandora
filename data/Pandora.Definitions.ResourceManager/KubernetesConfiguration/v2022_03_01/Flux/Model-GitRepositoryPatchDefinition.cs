using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.Flux;


internal class GitRepositoryPatchDefinitionModel
{
    [JsonPropertyName("httpsCACert")]
    public string? HTTPSCACert { get; set; }

    [JsonPropertyName("httpsUser")]
    public string? HTTPSUser { get; set; }

    [JsonPropertyName("localAuthRef")]
    public string? LocalAuthRef { get; set; }

    [JsonPropertyName("repositoryRef")]
    public RepositoryRefDefinitionModel? RepositoryRef { get; set; }

    [JsonPropertyName("sshKnownHosts")]
    public string? SshKnownHosts { get; set; }

    [JsonPropertyName("syncIntervalInSeconds")]
    public int? SyncIntervalInSeconds { get; set; }

    [JsonPropertyName("timeoutInSeconds")]
    public int? TimeoutInSeconds { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
