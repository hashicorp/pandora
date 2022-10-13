using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.StorageAccounts;


internal class StorageAccountSkuConversionStatusModel
{
    [JsonPropertyName("endTime")]
    public string? EndTime { get; set; }

    [JsonPropertyName("skuConversionStatus")]
    public SkuConversionStatusConstant? SkuConversionStatus { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }

    [JsonPropertyName("targetSkuName")]
    public SkuNameConstant? TargetSkuName { get; set; }
}
