using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.OperationalizationClusters;

[ValueForType("AKS")]
internal class AksComputeSecretsModel : ComputeSecretsModel
{
    [JsonPropertyName("adminKubeConfig")]
    public string? AdminKubeConfig { get; set; }

    [JsonPropertyName("imagePullSecretName")]
    public string? ImagePullSecretName { get; set; }

    [JsonPropertyName("userKubeConfig")]
    public string? UserKubeConfig { get; set; }
}
