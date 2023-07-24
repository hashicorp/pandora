using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class HostNameSslStateModel
{
    [JsonPropertyName("hostType")]
    public HostTypeConstant? HostType { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sslState")]
    public SslStateConstant? SslState { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("toUpdate")]
    public bool? ToUpdate { get; set; }

    [JsonPropertyName("virtualIP")]
    public string? VirtualIP { get; set; }
}
