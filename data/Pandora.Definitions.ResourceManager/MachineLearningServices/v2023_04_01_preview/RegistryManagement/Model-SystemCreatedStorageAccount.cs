using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.RegistryManagement;


internal class SystemCreatedStorageAccountModel
{
    [JsonPropertyName("allowBlobPublicAccess")]
    public bool? AllowBlobPublicAccess { get; set; }

    [JsonPropertyName("armResourceId")]
    public ArmResourceIdModel? ArmResourceId { get; set; }

    [JsonPropertyName("storageAccountHnsEnabled")]
    public bool? StorageAccountHnsEnabled { get; set; }

    [JsonPropertyName("storageAccountName")]
    public string? StorageAccountName { get; set; }

    [JsonPropertyName("storageAccountType")]
    public string? StorageAccountType { get; set; }
}
