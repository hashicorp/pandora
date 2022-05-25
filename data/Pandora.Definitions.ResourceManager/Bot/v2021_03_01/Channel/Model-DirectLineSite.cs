using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class DirectLineSiteModel
{
    [JsonPropertyName("isBlockUserUploadEnabled")]
    public bool? IsBlockUserUploadEnabled { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public bool IsEnabled { get; set; }

    [JsonPropertyName("isSecureSiteEnabled")]
    public bool? IsSecureSiteEnabled { get; set; }

    [JsonPropertyName("isV1Enabled")]
    [Required]
    public bool IsV1Enabled { get; set; }

    [JsonPropertyName("isV3Enabled")]
    [Required]
    public bool IsV3Enabled { get; set; }

    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("key2")]
    public string? Key2 { get; set; }

    [JsonPropertyName("siteId")]
    public string? SiteId { get; set; }

    [JsonPropertyName("siteName")]
    [Required]
    public string SiteName { get; set; }

    [JsonPropertyName("trustedOrigins")]
    public List<string>? TrustedOrigins { get; set; }
}
