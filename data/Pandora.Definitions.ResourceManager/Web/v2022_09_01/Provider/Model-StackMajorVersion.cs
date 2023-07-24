using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Provider;


internal class StackMajorVersionModel
{
    [JsonPropertyName("appSettingsDictionary")]
    public Dictionary<string, object>? AppSettingsDictionary { get; set; }

    [JsonPropertyName("applicationInsights")]
    public bool? ApplicationInsights { get; set; }

    [JsonPropertyName("displayVersion")]
    public string? DisplayVersion { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("isDeprecated")]
    public bool? IsDeprecated { get; set; }

    [JsonPropertyName("isHidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("isPreview")]
    public bool? IsPreview { get; set; }

    [JsonPropertyName("minorVersions")]
    public List<StackMinorVersionModel>? MinorVersions { get; set; }

    [JsonPropertyName("runtimeVersion")]
    public string? RuntimeVersion { get; set; }

    [JsonPropertyName("siteConfigPropertiesDictionary")]
    public Dictionary<string, object>? SiteConfigPropertiesDictionary { get; set; }
}
