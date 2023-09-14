using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervMachinesController;


internal class ExchangeServerModel
{
    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("roles")]
    public string? Roles { get; set; }

    [JsonPropertyName("servicePack")]
    public string? ServicePack { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
