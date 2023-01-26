using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ServiceTags;


internal class ServiceTagInformationPropertiesFormatModel
{
    [JsonPropertyName("addressPrefixes")]
    public List<string>? AddressPrefixes { get; set; }

    [JsonPropertyName("changeNumber")]
    public string? ChangeNumber { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("systemService")]
    public string? SystemService { get; set; }
}
