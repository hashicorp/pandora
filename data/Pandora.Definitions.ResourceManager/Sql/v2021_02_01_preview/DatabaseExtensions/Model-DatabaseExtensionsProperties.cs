using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.DatabaseExtensions;


internal class DatabaseExtensionsPropertiesModel
{
    [JsonPropertyName("operationMode")]
    [Required]
    public OperationModeConstant OperationMode { get; set; }

    [JsonPropertyName("storageKey")]
    [Required]
    public string StorageKey { get; set; }

    [JsonPropertyName("storageKeyType")]
    [Required]
    public StorageKeyTypeConstant StorageKeyType { get; set; }

    [JsonPropertyName("storageUri")]
    [Required]
    public string StorageUri { get; set; }
}
