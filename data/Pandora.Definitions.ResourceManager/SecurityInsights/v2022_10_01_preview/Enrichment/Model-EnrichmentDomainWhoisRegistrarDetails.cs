using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Enrichment;


internal class EnrichmentDomainWhoisRegistrarDetailsModel
{
    [JsonPropertyName("abuseContactEmail")]
    public string? AbuseContactEmail { get; set; }

    [JsonPropertyName("abuseContactPhone")]
    public string? AbuseContactPhone { get; set; }

    [JsonPropertyName("ianaId")]
    public string? IanaId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("whoisServer")]
    public string? WhoisServer { get; set; }
}
