using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationsManagement.v2015_11_01_preview.Solution;


internal class SolutionPropertiesModel
{
    [JsonPropertyName("containedResources")]
    public List<string>? ContainedResources { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("referencedResources")]
    public List<string>? ReferencedResources { get; set; }

    [JsonPropertyName("workspaceResourceId")]
    [Required]
    public string WorkspaceResourceId { get; set; }
}
