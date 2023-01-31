using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;


internal class VMMemoryModel
{
    [JsonPropertyName("currentMemoryUsageMB")]
    public int? CurrentMemoryUsageMB { get; set; }

    [JsonPropertyName("startupMemoryMB")]
    public int? StartupMemoryMB { get; set; }
}
