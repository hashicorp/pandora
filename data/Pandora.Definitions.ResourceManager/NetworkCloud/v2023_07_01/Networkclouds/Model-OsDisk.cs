using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class OsDiskModel
{
    [JsonPropertyName("createOption")]
    public OsDiskCreateOptionConstant? CreateOption { get; set; }

    [JsonPropertyName("deleteOption")]
    public OsDiskDeleteOptionConstant? DeleteOption { get; set; }

    [JsonPropertyName("diskSizeGB")]
    [Required]
    public int DiskSizeGB { get; set; }
}
