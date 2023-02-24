using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Factories;


internal abstract class FactoryRepoConfigurationModel
{
    [JsonPropertyName("accountName")]
    [Required]
    public string AccountName { get; set; }

    [JsonPropertyName("collaborationBranch")]
    [Required]
    public string CollaborationBranch { get; set; }

    [JsonPropertyName("disablePublish")]
    public bool? DisablePublish { get; set; }

    [JsonPropertyName("lastCommitId")]
    public string? LastCommitId { get; set; }

    [JsonPropertyName("repositoryName")]
    [Required]
    public string RepositoryName { get; set; }

    [JsonPropertyName("rootFolder")]
    [Required]
    public string RootFolder { get; set; }

    [JsonPropertyName("type")]
    [ProvidesTypeHint]
    [Required]
    public string Type { get; set; }
}
