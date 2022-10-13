using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;


internal class PersistentDiskModel
{
    [JsonPropertyName("mountPath")]
    public string? MountPath { get; set; }

    [JsonPropertyName("sizeInGB")]
    public int? SizeInGB { get; set; }

    [JsonPropertyName("usedInGB")]
    public int? UsedInGB { get; set; }
}
