using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;


internal class StaticSiteBasicAuthPropertiesARMResourcePropertiesModel
{
    [JsonPropertyName("applicableEnvironmentsMode")]
    [Required]
    public string ApplicableEnvironmentsMode { get; set; }

    [JsonPropertyName("environments")]
    public List<string>? Environments { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("secretState")]
    public string? SecretState { get; set; }

    [JsonPropertyName("secretUrl")]
    public string? SecretUrl { get; set; }
}
