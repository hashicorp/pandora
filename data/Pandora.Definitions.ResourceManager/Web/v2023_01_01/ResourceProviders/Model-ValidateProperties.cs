using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;


internal class ValidatePropertiesModel
{
    [JsonPropertyName("appServiceEnvironment")]
    public AppServiceEnvironmentModel? AppServiceEnvironment { get; set; }

    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    [JsonPropertyName("containerImagePlatform")]
    public string? ContainerImagePlatform { get; set; }

    [JsonPropertyName("containerImageRepository")]
    public string? ContainerImageRepository { get; set; }

    [JsonPropertyName("containerImageTag")]
    public string? ContainerImageTag { get; set; }

    [JsonPropertyName("containerRegistryBaseUrl")]
    public string? ContainerRegistryBaseUrl { get; set; }

    [JsonPropertyName("containerRegistryPassword")]
    public string? ContainerRegistryPassword { get; set; }

    [JsonPropertyName("containerRegistryUsername")]
    public string? ContainerRegistryUsername { get; set; }

    [JsonPropertyName("hostingEnvironment")]
    public string? HostingEnvironment { get; set; }

    [JsonPropertyName("isSpot")]
    public bool? IsSpot { get; set; }

    [JsonPropertyName("isXenon")]
    public bool? IsXenon { get; set; }

    [JsonPropertyName("needLinuxWorkers")]
    public bool? NeedLinuxWorkers { get; set; }

    [JsonPropertyName("serverFarmId")]
    public string? ServerFarmId { get; set; }

    [JsonPropertyName("skuName")]
    public string? SkuName { get; set; }
}
