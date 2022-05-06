using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class StorageAccountCreateParametersModel
{
    [JsonPropertyName("extendedLocation")]
    public ExtendedLocationModel? ExtendedLocation { get; set; }

    [JsonPropertyName("identity")]
    public CustomTypes.LegacySystemAndUserAssignedIdentityMap? Identity { get; set; }

    [JsonPropertyName("kind")]
    [Required]
    public KindConstant Kind { get; set; }

    [JsonPropertyName("location")]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [JsonPropertyName("properties")]
    public StorageAccountPropertiesCreateParametersModel? Properties { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public SkuModel Sku { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
