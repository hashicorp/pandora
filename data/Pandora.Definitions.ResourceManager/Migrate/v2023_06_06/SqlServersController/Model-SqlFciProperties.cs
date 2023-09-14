using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlServersController;


internal class SqlFciPropertiesModel
{
    [JsonPropertyName("isMultiSubnet")]
    public bool? IsMultiSubnet { get; set; }

    [JsonPropertyName("networkName")]
    public string? NetworkName { get; set; }

    [JsonPropertyName("sharedDiskCount")]
    public int? SharedDiskCount { get; set; }

    [JsonPropertyName("state")]
    public FCIInstanceStateConstant? State { get; set; }
}
