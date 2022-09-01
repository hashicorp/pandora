using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview.NamespacesAuthorizationRule;


internal class AccessKeysModel
{
    [JsonPropertyName("aliasPrimaryConnectionString")]
    public string? AliasPrimaryConnectionString { get; set; }

    [JsonPropertyName("aliasSecondaryConnectionString")]
    public string? AliasSecondaryConnectionString { get; set; }

    [JsonPropertyName("keyName")]
    public string? KeyName { get; set; }

    [JsonPropertyName("primaryConnectionString")]
    public string? PrimaryConnectionString { get; set; }

    [JsonPropertyName("primaryKey")]
    public string? PrimaryKey { get; set; }

    [JsonPropertyName("secondaryConnectionString")]
    public string? SecondaryConnectionString { get; set; }

    [JsonPropertyName("secondaryKey")]
    public string? SecondaryKey { get; set; }
}
