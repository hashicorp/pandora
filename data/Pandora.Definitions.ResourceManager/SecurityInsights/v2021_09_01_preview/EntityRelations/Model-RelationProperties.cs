using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.EntityRelations;


internal class RelationPropertiesModel
{
    [JsonPropertyName("relatedResourceId")]
    [Required]
    public string RelatedResourceId { get; set; }

    [JsonPropertyName("relatedResourceKind")]
    public string? RelatedResourceKind { get; set; }

    [JsonPropertyName("relatedResourceName")]
    public string? RelatedResourceName { get; set; }

    [JsonPropertyName("relatedResourceType")]
    public string? RelatedResourceType { get; set; }
}
