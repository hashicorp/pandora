using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.VMwareHostController;


internal class VMwareDatastoreModel
{
    [JsonPropertyName("capacityInGb")]
    public float? CapacityInGb { get; set; }

    [JsonPropertyName("freeSpaceInGb")]
    public float? FreeSpaceInGb { get; set; }

    [JsonPropertyName("symbolicName")]
    public string? SymbolicName { get; set; }

    [JsonPropertyName("type")]
    public VMwareDatastoreTypeConstant? Type { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
}
