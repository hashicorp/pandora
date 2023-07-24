using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class CsmDeploymentStatusPropertiesModel
{
    [JsonPropertyName("deploymentId")]
    public string? DeploymentId { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorEntityModel>? Errors { get; set; }

    [JsonPropertyName("failedInstancesLogs")]
    public List<string>? FailedInstancesLogs { get; set; }

    [JsonPropertyName("numberOfInstancesFailed")]
    public int? NumberOfInstancesFailed { get; set; }

    [JsonPropertyName("numberOfInstancesInProgress")]
    public int? NumberOfInstancesInProgress { get; set; }

    [JsonPropertyName("numberOfInstancesSuccessful")]
    public int? NumberOfInstancesSuccessful { get; set; }

    [JsonPropertyName("status")]
    public DeploymentBuildStatusConstant? Status { get; set; }
}
