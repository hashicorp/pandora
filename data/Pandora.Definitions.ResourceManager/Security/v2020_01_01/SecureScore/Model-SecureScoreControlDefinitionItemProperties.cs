using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.SecureScore;


internal class SecureScoreControlDefinitionItemPropertiesModel
{
    [JsonPropertyName("assessmentDefinitions")]
    public List<AzureResourceLinkModel>? AssessmentDefinitions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("maxScore")]
    public int? MaxScore { get; set; }

    [JsonPropertyName("source")]
    public SecureScoreControlDefinitionSourceModel? Source { get; set; }
}
