using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.ModelVersion;


internal class PackageRequestModel
{
    [JsonPropertyName("baseEnvironmentSource")]
    public BaseEnvironmentSourceModel? BaseEnvironmentSource { get; set; }

    [JsonPropertyName("environmentVariables")]
    public Dictionary<string, string>? EnvironmentVariables { get; set; }

    [JsonPropertyName("inferencingServer")]
    [Required]
    public InferencingServerModel InferencingServer { get; set; }

    [JsonPropertyName("inputs")]
    public List<ModelPackageInputModel>? Inputs { get; set; }

    [JsonPropertyName("modelConfiguration")]
    public ModelConfigurationModel? ModelConfiguration { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("targetEnvironmentName")]
    [Required]
    public string TargetEnvironmentName { get; set; }

    [JsonPropertyName("targetEnvironmentVersion")]
    public string? TargetEnvironmentVersion { get; set; }
}
