using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.StorageTargets;


internal class BlobNfsTargetModel
{
    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("usageModel")]
    public string? UsageModel { get; set; }
}
