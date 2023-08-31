using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class MachineDiskModel
{
    [JsonPropertyName("capacityGB")]
    public int? CapacityGB { get; set; }

    [JsonPropertyName("connection")]
    public MachineSkuDiskConnectionTypeConstant? Connection { get; set; }

    [JsonPropertyName("type")]
    public DiskTypeConstant? Type { get; set; }
}
