using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryApplicationVersions;


internal class UserArtifactManageModel
{
    [JsonPropertyName("install")]
    [Required]
    public string Install { get; set; }

    [JsonPropertyName("remove")]
    [Required]
    public string Remove { get; set; }

    [JsonPropertyName("update")]
    public string? Update { get; set; }
}
