using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.Volumes;


internal class VolumeUpdatePropertiesModel
{
    [JsonPropertyName("managedBy")]
    public ManagedByInfoModel? ManagedBy { get; set; }

    [JsonPropertyName("sizeGiB")]
    public int? SizeGiB { get; set; }
}
