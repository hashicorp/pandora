using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.EnvironmentVersion;


internal class EnvironmentVersionModel
{
    [JsonPropertyName("autoRebuild")]
    public AutoRebuildSettingConstant? AutoRebuild { get; set; }

    [JsonPropertyName("build")]
    public BuildContextModel? Build { get; set; }

    [JsonPropertyName("condaFile")]
    public string? CondaFile { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("environmentType")]
    public EnvironmentTypeConstant? EnvironmentType { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("inferenceConfig")]
    public InferenceContainerPropertiesModel? InferenceConfig { get; set; }

    [JsonPropertyName("isAnonymous")]
    public bool? IsAnonymous { get; set; }

    [JsonPropertyName("isArchived")]
    public bool? IsArchived { get; set; }

    [JsonPropertyName("osType")]
    public OperatingSystemTypeConstant? OsType { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
