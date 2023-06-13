using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LocationCapabilities;


internal class ServerVersionCapabilityModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedEditions")]
    public List<EditionCapabilityModel>? SupportedEditions { get; set; }

    [JsonPropertyName("supportedElasticPoolEditions")]
    public List<ElasticPoolEditionCapabilityModel>? SupportedElasticPoolEditions { get; set; }
}
