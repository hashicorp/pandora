using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedServerDnsAliases;


internal class ManagedServerDnsAliasPropertiesModel
{
    [JsonPropertyName("azureDnsRecord")]
    public string? AzureDnsRecord { get; set; }

    [JsonPropertyName("publicAzureDnsRecord")]
    public string? PublicAzureDnsRecord { get; set; }
}
