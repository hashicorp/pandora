using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Provider;


internal class LinuxJavaContainerSettingsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endOfLifeDate")]
    public DateTime? EndOfLifeDate { get; set; }

    [JsonPropertyName("isAutoUpdate")]
    public bool? IsAutoUpdate { get; set; }

    [JsonPropertyName("isDeprecated")]
    public bool? IsDeprecated { get; set; }

    [JsonPropertyName("isEarlyAccess")]
    public bool? IsEarlyAccess { get; set; }

    [JsonPropertyName("isHidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("isPreview")]
    public bool? IsPreview { get; set; }

    [JsonPropertyName("java11Runtime")]
    public string? Java11Runtime { get; set; }

    [JsonPropertyName("java8Runtime")]
    public string? Java8Runtime { get; set; }
}
