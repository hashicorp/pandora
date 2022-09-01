using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Deployments;


internal class DeploymentPropertiesExtendedModel
{
    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("debugSetting")]
    public DebugSettingModel? DebugSetting { get; set; }

    [JsonPropertyName("dependencies")]
    public List<DependencyModel>? Dependencies { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("error")]
    public ErrorResponseModel? Error { get; set; }

    [JsonPropertyName("mode")]
    public DeploymentModeConstant? Mode { get; set; }

    [JsonPropertyName("onErrorDeployment")]
    public OnErrorDeploymentExtendedModel? OnErrorDeployment { get; set; }

    [JsonPropertyName("outputResources")]
    public List<ResourceReferenceModel>? OutputResources { get; set; }

    [JsonPropertyName("outputs")]
    public object? Outputs { get; set; }

    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }

    [JsonPropertyName("parametersLink")]
    public ParametersLinkModel? ParametersLink { get; set; }

    [JsonPropertyName("providers")]
    public List<ProviderModel>? Providers { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("templateHash")]
    public string? TemplateHash { get; set; }

    [JsonPropertyName("templateLink")]
    public TemplateLinkModel? TemplateLink { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("validatedResources")]
    public List<ResourceReferenceModel>? ValidatedResources { get; set; }
}
