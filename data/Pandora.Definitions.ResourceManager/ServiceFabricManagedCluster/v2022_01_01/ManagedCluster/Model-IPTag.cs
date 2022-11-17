using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.ManagedCluster;


internal class IPTagModel
{
    [JsonPropertyName("ipTagType")]
    [Required]
    public string IPTagType { get; set; }

    [JsonPropertyName("tag")]
    [Required]
    public string Tag { get; set; }
}
