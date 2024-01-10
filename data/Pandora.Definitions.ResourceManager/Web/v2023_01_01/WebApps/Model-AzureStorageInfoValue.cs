using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class AzureStorageInfoValueModel
{
    [JsonPropertyName("accessKey")]
    public string? AccessKey { get; set; }

    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("mountPath")]
    public string? MountPath { get; set; }

    [JsonPropertyName("shareName")]
    public string? ShareName { get; set; }

    [JsonPropertyName("state")]
    public AzureStorageStateConstant? State { get; set; }

    [JsonPropertyName("type")]
    public AzureStorageTypeConstant? Type { get; set; }
}
