using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Workspaces;


internal class WorkspacePropertiesUpdateParametersModel
{
    [JsonPropertyName("applicationInsights")]
    public string? ApplicationInsights { get; set; }

    [JsonPropertyName("containerRegistry")]
    public string? ContainerRegistry { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("featureStoreSettings")]
    public FeatureStoreSettingsModel? FeatureStoreSettings { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("imageBuildCompute")]
    public string? ImageBuildCompute { get; set; }

    [JsonPropertyName("primaryUserAssignedIdentity")]
    public string? PrimaryUserAssignedIdentity { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("serverlessComputeSettings")]
    public ServerlessComputeSettingsModel? ServerlessComputeSettings { get; set; }

    [JsonPropertyName("serviceManagedResourcesSettings")]
    public ServiceManagedResourcesSettingsModel? ServiceManagedResourcesSettings { get; set; }
}
