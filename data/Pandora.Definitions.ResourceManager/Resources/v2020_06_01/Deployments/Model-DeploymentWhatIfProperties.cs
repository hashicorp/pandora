using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Deployments;


internal class DeploymentWhatIfPropertiesModel
{
    [JsonPropertyName("debugSetting")]
    public DebugSettingModel? DebugSetting { get; set; }

    [JsonPropertyName("expressionEvaluationOptions")]
    public ExpressionEvaluationOptionsModel? ExpressionEvaluationOptions { get; set; }

    [JsonPropertyName("mode")]
    [Required]
    public DeploymentModeConstant Mode { get; set; }

    [JsonPropertyName("onErrorDeployment")]
    public OnErrorDeploymentModel? OnErrorDeployment { get; set; }

    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }

    [JsonPropertyName("parametersLink")]
    public ParametersLinkModel? ParametersLink { get; set; }

    [JsonPropertyName("template")]
    public object? Template { get; set; }

    [JsonPropertyName("templateLink")]
    public TemplateLinkModel? TemplateLink { get; set; }

    [JsonPropertyName("whatIfSettings")]
    public DeploymentWhatIfSettingsModel? WhatIfSettings { get; set; }
}
