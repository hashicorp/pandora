using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class PushSettingsPropertiesModel
{
    [JsonPropertyName("dynamicTagsJson")]
    public string? DynamicTagsJson { get; set; }

    [JsonPropertyName("isPushEnabled")]
    [Required]
    public bool IsPushEnabled { get; set; }

    [JsonPropertyName("tagWhitelistJson")]
    public string? TagWhitelistJson { get; set; }

    [JsonPropertyName("tagsRequiringAuth")]
    public string? TagsRequiringAuth { get; set; }
}
