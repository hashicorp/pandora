using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.Galleries;


internal class CommunityGalleryInfoModel
{
    [JsonPropertyName("communityGalleryEnabled")]
    public bool? CommunityGalleryEnabled { get; set; }

    [JsonPropertyName("eula")]
    public string? Eula { get; set; }

    [JsonPropertyName("publicNamePrefix")]
    public string? PublicNamePrefix { get; set; }

    [JsonPropertyName("publicNames")]
    public List<string>? PublicNames { get; set; }

    [JsonPropertyName("publisherContact")]
    public string? PublisherContact { get; set; }

    [JsonPropertyName("publisherUri")]
    public string? PublisherUri { get; set; }
}
