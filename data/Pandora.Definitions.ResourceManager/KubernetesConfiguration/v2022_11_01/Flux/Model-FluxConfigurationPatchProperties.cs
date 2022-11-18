using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.Flux;


internal class FluxConfigurationPatchPropertiesModel
{
    [JsonPropertyName("azureBlob")]
    public AzureBlobPatchDefinitionModel? AzureBlob { get; set; }

    [JsonPropertyName("bucket")]
    public BucketPatchDefinitionModel? Bucket { get; set; }

    [JsonPropertyName("configurationProtectedSettings")]
    public Dictionary<string, string>? ConfigurationProtectedSettings { get; set; }

    [JsonPropertyName("gitRepository")]
    public GitRepositoryPatchDefinitionModel? GitRepository { get; set; }

    [JsonPropertyName("kustomizations")]
    public Dictionary<string, KustomizationPatchDefinitionModel>? Kustomizations { get; set; }

    [JsonPropertyName("sourceKind")]
    public SourceKindTypeConstant? SourceKind { get; set; }

    [JsonPropertyName("suspend")]
    public bool? Suspend { get; set; }
}
