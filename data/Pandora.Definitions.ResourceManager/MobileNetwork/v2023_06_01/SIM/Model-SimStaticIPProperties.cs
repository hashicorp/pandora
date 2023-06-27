using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.SIM;


internal class SimStaticIPPropertiesModel
{
    [JsonPropertyName("attachedDataNetwork")]
    public AttachedDataNetworkResourceIdModel? AttachedDataNetwork { get; set; }

    [JsonPropertyName("slice")]
    public SliceResourceIdModel? Slice { get; set; }

    [JsonPropertyName("staticIp")]
    public SimStaticIPPropertiesStaticIPModel? StaticIP { get; set; }
}
