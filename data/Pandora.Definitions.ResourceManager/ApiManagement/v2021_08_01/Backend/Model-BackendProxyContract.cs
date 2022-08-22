using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Backend;


internal class BackendProxyContractModel
{
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("url")]
    [Required]
    public string Url { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
