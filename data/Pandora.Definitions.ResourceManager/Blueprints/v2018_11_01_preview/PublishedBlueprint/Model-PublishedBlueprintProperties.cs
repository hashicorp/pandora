using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.PublishedBlueprint;


internal class PublishedBlueprintPropertiesModel
{
    [JsonPropertyName("blueprintName")]
    public string? BlueprintName { get; set; }

    [JsonPropertyName("changeNotes")]
    public string? ChangeNotes { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, ParameterDefinitionModel>? Parameters { get; set; }

    [JsonPropertyName("resourceGroups")]
    public Dictionary<string, ResourceGroupDefinitionModel>? ResourceGroups { get; set; }

    [JsonPropertyName("status")]
    public BlueprintResourceStatusBaseModel? Status { get; set; }

    [JsonPropertyName("targetScope")]
    public BlueprintTargetScopeConstant? TargetScope { get; set; }
}
