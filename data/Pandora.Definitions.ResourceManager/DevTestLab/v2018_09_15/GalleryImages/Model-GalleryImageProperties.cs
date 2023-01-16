using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.GalleryImages;


internal class GalleryImagePropertiesModel
{
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("imageReference")]
    public GalleryImageReferenceModel? ImageReference { get; set; }

    [JsonPropertyName("isPlanAuthorized")]
    public bool? IsPlanAuthorized { get; set; }

    [JsonPropertyName("planId")]
    public string? PlanId { get; set; }
}
