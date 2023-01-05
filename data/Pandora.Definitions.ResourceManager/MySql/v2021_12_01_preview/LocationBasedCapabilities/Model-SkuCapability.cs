using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.LocationBasedCapabilities;


internal class SkuCapabilityModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("supportedIops")]
    public int? SupportedIops { get; set; }

    [JsonPropertyName("supportedMemoryPerVCoreMB")]
    public int? SupportedMemoryPerVCoreMB { get; set; }

    [JsonPropertyName("vCores")]
    public int? VCores { get; set; }
}
