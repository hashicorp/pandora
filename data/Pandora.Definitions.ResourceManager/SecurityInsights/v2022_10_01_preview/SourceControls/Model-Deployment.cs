using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.SourceControls;


internal class DeploymentModel
{
    [JsonPropertyName("deploymentId")]
    public string? DeploymentId { get; set; }

    [JsonPropertyName("deploymentLogsUrl")]
    public string? DeploymentLogsUrl { get; set; }

    [JsonPropertyName("deploymentResult")]
    public DeploymentResultConstant? DeploymentResult { get; set; }

    [JsonPropertyName("deploymentState")]
    public DeploymentStateConstant? DeploymentState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deploymentTime")]
    public DateTime? DeploymentTime { get; set; }
}
