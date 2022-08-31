using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.DeletedAccounts;


internal class DeletedAccountPropertiesModel
{
    [JsonPropertyName("creationTime")]
    public string? CreationTime { get; set; }

    [JsonPropertyName("deletionTime")]
    public string? DeletionTime { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("restoreReference")]
    public string? RestoreReference { get; set; }

    [JsonPropertyName("storageAccountResourceId")]
    public string? StorageAccountResourceId { get; set; }
}
