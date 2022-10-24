using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Enrichment;


internal class EnrichmentIPGeodataModel
{
    [JsonPropertyName("asn")]
    public string? Asn { get; set; }

    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("cityCf")]
    public int? CityCf { get; set; }

    [JsonPropertyName("continent")]
    public string? Continent { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("countryCf")]
    public int? CountryCf { get; set; }

    [JsonPropertyName("ipAddr")]
    public string? IPAddr { get; set; }

    [JsonPropertyName("ipRoutingType")]
    public string? IPRoutingType { get; set; }

    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    [JsonPropertyName("organization")]
    public string? Organization { get; set; }

    [JsonPropertyName("organizationType")]
    public string? OrganizationType { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("stateCf")]
    public int? StateCf { get; set; }

    [JsonPropertyName("stateCode")]
    public string? StateCode { get; set; }
}
