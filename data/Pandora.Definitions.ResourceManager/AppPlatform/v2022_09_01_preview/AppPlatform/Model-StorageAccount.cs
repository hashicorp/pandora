using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

[ValueForType("StorageAccount")]
internal class StorageAccountModel : StoragePropertiesModel
{
    [JsonPropertyName("accountKey")]
    [Required]
    public string AccountKey { get; set; }

    [JsonPropertyName("accountName")]
    [Required]
    public string AccountName { get; set; }
}
