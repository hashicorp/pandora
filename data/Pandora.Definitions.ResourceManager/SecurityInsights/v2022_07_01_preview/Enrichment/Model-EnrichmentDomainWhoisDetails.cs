using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Enrichment;


internal class EnrichmentDomainWhoisDetailsModel
{
    [JsonPropertyName("contacts")]
    public EnrichmentDomainWhoisContactsModel? Contacts { get; set; }

    [JsonPropertyName("nameServers")]
    public List<string>? NameServers { get; set; }

    [JsonPropertyName("registrar")]
    public EnrichmentDomainWhoisRegistrarDetailsModel? Registrar { get; set; }

    [JsonPropertyName("statuses")]
    public List<string>? Statuses { get; set; }
}
