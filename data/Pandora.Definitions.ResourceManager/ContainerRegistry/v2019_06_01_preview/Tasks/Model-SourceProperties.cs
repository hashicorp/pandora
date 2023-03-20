using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;


internal class SourcePropertiesModel
{
    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("repositoryUrl")]
    [Required]
    public string RepositoryUrl { get; set; }

    [JsonPropertyName("sourceControlAuthProperties")]
    public AuthInfoModel? SourceControlAuthProperties { get; set; }

    [JsonPropertyName("sourceControlType")]
    [Required]
    public SourceControlTypeConstant SourceControlType { get; set; }
}
