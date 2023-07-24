using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.KubeEnvironments;


internal class ArcConfigurationModel
{
    [JsonPropertyName("artifactStorageAccessMode")]
    public string? ArtifactStorageAccessMode { get; set; }

    [JsonPropertyName("artifactStorageClassName")]
    public string? ArtifactStorageClassName { get; set; }

    [JsonPropertyName("artifactStorageMountPath")]
    public string? ArtifactStorageMountPath { get; set; }

    [JsonPropertyName("artifactStorageNodeName")]
    public string? ArtifactStorageNodeName { get; set; }

    [JsonPropertyName("artifactsStorageType")]
    public StorageTypeConstant? ArtifactsStorageType { get; set; }

    [JsonPropertyName("frontEndServiceConfiguration")]
    public FrontEndConfigurationModel? FrontEndServiceConfiguration { get; set; }

    [JsonPropertyName("kubeConfig")]
    public string? KubeConfig { get; set; }
}
