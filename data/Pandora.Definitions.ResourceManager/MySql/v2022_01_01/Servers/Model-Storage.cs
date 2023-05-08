using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2022_01_01.Servers;


internal class StorageModel
{
    [JsonPropertyName("autoGrow")]
    public EnableStatusEnumConstant? AutoGrow { get; set; }

    [JsonPropertyName("autoIoScaling")]
    public EnableStatusEnumConstant? AutoIoScaling { get; set; }

    [JsonPropertyName("iops")]
    public int? Iops { get; set; }

    [JsonPropertyName("logOnDisk")]
    public EnableStatusEnumConstant? LogOnDisk { get; set; }

    [JsonPropertyName("storageSizeGB")]
    public int? StorageSizeGB { get; set; }

    [JsonPropertyName("storageSku")]
    public string? StorageSku { get; set; }
}
