using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApi;


internal class ApiResourceMetadataModel
{
    [JsonPropertyName("ApiType")]
    public ApiTypeConstant? ApiType { get; set; }

    [JsonPropertyName("brandColor")]
    public string? BrandColor { get; set; }

    [JsonPropertyName("connectionType")]
    public string? ConnectionType { get; set; }

    [JsonPropertyName("deploymentParameters")]
    public ApiDeploymentParameterMetadataSetModel? DeploymentParameters { get; set; }

    [JsonPropertyName("hideKey")]
    public string? HideKey { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkflowProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("wsdlImportMethod")]
    public WsdlImportMethodConstant? WsdlImportMethod { get; set; }

    [JsonPropertyName("wsdlService")]
    public WsdlServiceModel? WsdlService { get; set; }
}
