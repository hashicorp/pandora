using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PrivateClouds;


internal class IdentitySourceModel
{
    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

    [JsonPropertyName("baseGroupDN")]
    public string? BaseGroupDN { get; set; }

    [JsonPropertyName("baseUserDN")]
    public string? BaseUserDN { get; set; }

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("primaryServer")]
    public string? PrimaryServer { get; set; }

    [JsonPropertyName("secondaryServer")]
    public string? SecondaryServer { get; set; }

    [JsonPropertyName("ssl")]
    public SslEnumConstant? Ssl { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
