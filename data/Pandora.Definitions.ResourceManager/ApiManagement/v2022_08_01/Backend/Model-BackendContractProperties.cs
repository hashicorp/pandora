using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Backend;


internal class BackendContractPropertiesModel
{
    [JsonPropertyName("credentials")]
    public BackendCredentialsContractModel? Credentials { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("properties")]
    public BackendPropertiesModel? Properties { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public BackendProtocolConstant Protocol { get; set; }

    [JsonPropertyName("proxy")]
    public BackendProxyContractModel? Proxy { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("tls")]
    public BackendTlsPropertiesModel? Tls { get; set; }

    [JsonPropertyName("url")]
    [Required]
    public string Url { get; set; }
}
