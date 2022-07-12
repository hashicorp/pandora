using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_10_01.ContainerInstance;


internal class VolumeModel
{
    [JsonPropertyName("azureFile")]
    public AzureFileVolumeModel? AzureFile { get; set; }

    [JsonPropertyName("emptyDir")]
    public object? EmptyDir { get; set; }

    [JsonPropertyName("gitRepo")]
    public GitRepoVolumeModel? GitRepo { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("secret")]
    public Dictionary<string, string>? Secret { get; set; }
}
