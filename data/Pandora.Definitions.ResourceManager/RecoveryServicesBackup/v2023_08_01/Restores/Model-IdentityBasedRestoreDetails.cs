using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.Restores;


internal class IdentityBasedRestoreDetailsModel
{
    [JsonPropertyName("objectType")]
    public string? ObjectType { get; set; }

    [JsonPropertyName("targetStorageAccountId")]
    public string? TargetStorageAccountId { get; set; }
}
