using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.Pool;


internal class AzureFileShareConfigurationModel
{
    [JsonPropertyName("accountKey")]
    [Required]
    public string AccountKey { get; set; }

    [JsonPropertyName("accountName")]
    [Required]
    public string AccountName { get; set; }

    [JsonPropertyName("azureFileUrl")]
    [Required]
    public string AzureFileUrl { get; set; }

    [JsonPropertyName("mountOptions")]
    public string? MountOptions { get; set; }

    [JsonPropertyName("relativeMountPath")]
    [Required]
    public string RelativeMountPath { get; set; }
}
