using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;


internal class StaticSiteBuildPropertiesModel
{
    [JsonPropertyName("apiBuildCommand")]
    public string? ApiBuildCommand { get; set; }

    [JsonPropertyName("apiLocation")]
    public string? ApiLocation { get; set; }

    [JsonPropertyName("appArtifactLocation")]
    public string? AppArtifactLocation { get; set; }

    [JsonPropertyName("appBuildCommand")]
    public string? AppBuildCommand { get; set; }

    [JsonPropertyName("appLocation")]
    public string? AppLocation { get; set; }

    [JsonPropertyName("githubActionSecretNameOverride")]
    public string? GitHubActionSecretNameOverride { get; set; }

    [JsonPropertyName("outputLocation")]
    public string? OutputLocation { get; set; }

    [JsonPropertyName("skipGithubActionWorkflowGeneration")]
    public bool? SkipGithubActionWorkflowGeneration { get; set; }
}
