using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Enrichment;


internal class EnrichmentDomainWhoisContactsModel
{
    [JsonPropertyName("admin")]
    public EnrichmentDomainWhoisContactModel? Admin { get; set; }

    [JsonPropertyName("billing")]
    public EnrichmentDomainWhoisContactModel? Billing { get; set; }

    [JsonPropertyName("registrant")]
    public EnrichmentDomainWhoisContactModel? Registrant { get; set; }

    [JsonPropertyName("tech")]
    public EnrichmentDomainWhoisContactModel? Tech { get; set; }
}
