using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.Archives;


internal class ArchivePropertiesModel
{
    [JsonPropertyName("packageSource")]
    public ArchivePackageSourcePropertiesModel? PackageSource { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publishedVersion")]
    public string? PublishedVersion { get; set; }

    [JsonPropertyName("repositoryEndpoint")]
    public string? RepositoryEndpoint { get; set; }

    [JsonPropertyName("repositoryEndpointPrefix")]
    public string? RepositoryEndpointPrefix { get; set; }
}
