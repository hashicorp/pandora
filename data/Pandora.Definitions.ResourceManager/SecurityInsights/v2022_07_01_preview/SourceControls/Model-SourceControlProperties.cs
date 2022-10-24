using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.SourceControls;


internal class SourceControlPropertiesModel
{
    [JsonPropertyName("contentTypes")]
    [Required]
    public List<ContentTypeConstant> ContentTypes { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastDeploymentInfo")]
    public DeploymentInfoModel? LastDeploymentInfo { get; set; }

    [JsonPropertyName("repoType")]
    [Required]
    public RepoTypeConstant RepoType { get; set; }

    [JsonPropertyName("repository")]
    [Required]
    public RepositoryModel Repository { get; set; }

    [JsonPropertyName("repositoryResourceInfo")]
    public RepositoryResourceInfoModel? RepositoryResourceInfo { get; set; }

    [JsonPropertyName("version")]
    public VersionConstant? Version { get; set; }
}
