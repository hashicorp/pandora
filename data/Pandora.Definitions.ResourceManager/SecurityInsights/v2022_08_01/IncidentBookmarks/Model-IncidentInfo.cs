using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.IncidentBookmarks;


internal class IncidentInfoModel
{
    [JsonPropertyName("incidentId")]
    public string? IncidentId { get; set; }

    [JsonPropertyName("relationName")]
    public string? RelationName { get; set; }

    [JsonPropertyName("severity")]
    public IncidentSeverityConstant? Severity { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
