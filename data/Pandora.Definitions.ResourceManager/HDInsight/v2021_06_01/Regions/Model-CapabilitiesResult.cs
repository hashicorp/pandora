using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;


internal class CapabilitiesResultModel
{
    [JsonPropertyName("features")]
    public List<string>? Features { get; set; }

    [JsonPropertyName("quota")]
    public QuotaCapabilityModel? Quota { get; set; }

    [JsonPropertyName("regions")]
    public Dictionary<string, RegionsCapabilityModel>? Regions { get; set; }

    [JsonPropertyName("versions")]
    public Dictionary<string, VersionsCapabilityModel>? Versions { get; set; }
}
