using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Workspaces;


internal class FeatureStoreSettingsModel
{
    [JsonPropertyName("computeRuntime")]
    public ComputeRuntimeDtoModel? ComputeRuntime { get; set; }

    [JsonPropertyName("offlineStoreConnectionName")]
    public string? OfflineStoreConnectionName { get; set; }

    [JsonPropertyName("onlineStoreConnectionName")]
    public string? OnlineStoreConnectionName { get; set; }
}
