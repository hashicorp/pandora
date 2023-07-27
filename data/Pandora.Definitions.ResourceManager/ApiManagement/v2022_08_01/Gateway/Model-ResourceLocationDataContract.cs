using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Gateway;


internal class ResourceLocationDataContractModel
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("countryOrRegion")]
    public string? CountryOrRegion { get; set; }

    [JsonPropertyName("district")]
    public string? District { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
