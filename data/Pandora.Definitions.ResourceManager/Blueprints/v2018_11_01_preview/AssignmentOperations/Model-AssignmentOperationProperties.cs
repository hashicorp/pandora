using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.AssignmentOperations;


internal class AssignmentOperationPropertiesModel
{
    [JsonPropertyName("assignmentState")]
    public string? AssignmentState { get; set; }

    [JsonPropertyName("blueprintVersion")]
    public string? BlueprintVersion { get; set; }

    [JsonPropertyName("deployments")]
    public List<AssignmentDeploymentJobModel>? Deployments { get; set; }

    [JsonPropertyName("timeCreated")]
    public string? TimeCreated { get; set; }

    [JsonPropertyName("timeFinished")]
    public string? TimeFinished { get; set; }

    [JsonPropertyName("timeStarted")]
    public string? TimeStarted { get; set; }
}
