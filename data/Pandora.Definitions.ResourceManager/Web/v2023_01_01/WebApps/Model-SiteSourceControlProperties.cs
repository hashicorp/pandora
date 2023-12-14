using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class SiteSourceControlPropertiesModel
{
    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("deploymentRollbackEnabled")]
    public bool? DeploymentRollbackEnabled { get; set; }

    [JsonPropertyName("gitHubActionConfiguration")]
    public GitHubActionConfigurationModel? GitHubActionConfiguration { get; set; }

    [JsonPropertyName("isGitHubAction")]
    public bool? IsGitHubAction { get; set; }

    [JsonPropertyName("isManualIntegration")]
    public bool? IsManualIntegration { get; set; }

    [JsonPropertyName("isMercurial")]
    public bool? IsMercurial { get; set; }

    [JsonPropertyName("repoUrl")]
    public string? RepoUrl { get; set; }
}
