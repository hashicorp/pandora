using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectableItems;

[ValueForType("AzureFileShare")]
internal class AzureFileShareProtectableItemModel : WorkloadProtectableItemModel
{
    [JsonPropertyName("azureFileShareType")]
    public AzureFileShareTypeConstant? AzureFileShareType { get; set; }

    [JsonPropertyName("parentContainerFabricId")]
    public string? ParentContainerFabricId { get; set; }

    [JsonPropertyName("parentContainerFriendlyName")]
    public string? ParentContainerFriendlyName { get; set; }
}
