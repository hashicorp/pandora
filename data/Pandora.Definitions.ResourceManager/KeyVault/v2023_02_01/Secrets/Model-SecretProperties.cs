using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.Secrets;


internal class SecretPropertiesModel
{
    [JsonPropertyName("attributes")]
    public AttributesModel? Attributes { get; set; }

    [JsonPropertyName("contentType")]
    public string? ContentType { get; set; }

    [JsonPropertyName("secretUri")]
    public string? SecretUri { get; set; }

    [JsonPropertyName("secretUriWithVersion")]
    public string? SecretUriWithVersion { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
