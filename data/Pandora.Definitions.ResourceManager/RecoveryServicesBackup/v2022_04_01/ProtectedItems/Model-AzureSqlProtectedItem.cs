using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.ProtectedItems;

[ValueForType("Microsoft.Sql/servers/databases")]
internal class AzureSqlProtectedItemModel : ProtectedItemModel
{
    [JsonPropertyName("extendedInfo")]
    public AzureSqlProtectedItemExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("protectedItemDataId")]
    public string? ProtectedItemDataId { get; set; }

    [JsonPropertyName("protectionState")]
    public ProtectedItemStateConstant? ProtectionState { get; set; }
}
