using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.AttachedDataNetworks;


internal class PortRangeModel
{
    [JsonPropertyName("maxPort")]
    public int? MaxPort { get; set; }

    [JsonPropertyName("minPort")]
    public int? MinPort { get; set; }
}
