using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectedItems;

[ValueForType("GenericProtectedItem")]
internal class GenericProtectedItemModel : ProtectedItemModel
{
    [JsonPropertyName("fabricName")]
    public string? FabricName { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("policyState")]
    public string? PolicyState { get; set; }

    [JsonPropertyName("protectedItemId")]
    public int? ProtectedItemId { get; set; }

    [JsonPropertyName("protectionState")]
    public ProtectionStateConstant? ProtectionState { get; set; }

    [JsonPropertyName("sourceAssociations")]
    public Dictionary<string, string>? SourceAssociations { get; set; }
}
