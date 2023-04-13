using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.AssignmentOperations;


internal class AssignmentDeploymentJobModel
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("history")]
    public List<AssignmentDeploymentJobResultModel>? History { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("jobState")]
    public string? JobState { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("requestUri")]
    public string? RequestUri { get; set; }

    [JsonPropertyName("result")]
    public AssignmentDeploymentJobResultModel? Result { get; set; }
}
