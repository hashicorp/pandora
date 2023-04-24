using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;


internal class AmlFilesystemContainerStorageInterfaceModel
{
    [JsonPropertyName("persistentVolume")]
    public string? PersistentVolume { get; set; }

    [JsonPropertyName("persistentVolumeClaim")]
    public string? PersistentVolumeClaim { get; set; }

    [JsonPropertyName("storageClass")]
    public string? StorageClass { get; set; }
}
