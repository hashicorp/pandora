using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Domains;


internal class AddressModel
{
    [JsonPropertyName("address1")]
    [Required]
    public string Address1 { get; set; }

    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("city")]
    [Required]
    public string City { get; set; }

    [JsonPropertyName("country")]
    [Required]
    public string Country { get; set; }

    [JsonPropertyName("postalCode")]
    [Required]
    public string PostalCode { get; set; }

    [JsonPropertyName("state")]
    [Required]
    public string State { get; set; }
}
