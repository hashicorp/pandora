using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.Agreements;


internal class DatadogAgreementPropertiesModel
{
    [JsonPropertyName("accepted")]
    public bool? Accepted { get; set; }

    [JsonPropertyName("licenseTextLink")]
    public string? LicenseTextLink { get; set; }

    [JsonPropertyName("plan")]
    public string? Plan { get; set; }

    [JsonPropertyName("privacyPolicyLink")]
    public string? PrivacyPolicyLink { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("retrieveDatetime")]
    public DateTime? RetrieveDatetime { get; set; }

    [JsonPropertyName("signature")]
    public string? Signature { get; set; }
}
