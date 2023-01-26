using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PacketCaptures;


internal class PacketCaptureMachineScopeModel
{
    [JsonPropertyName("exclude")]
    public List<string>? Exclude { get; set; }

    [JsonPropertyName("include")]
    public List<string>? Include { get; set; }
}
