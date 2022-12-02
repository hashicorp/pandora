using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupPolicies;


internal abstract class ProtectionPolicyModel
{
    [JsonPropertyName("backupManagementType")]
    [ProvidesTypeHint]
    [Required]
    public string BackupManagementType { get; set; }

    [JsonPropertyName("protectedItemsCount")]
    public int? ProtectedItemsCount { get; set; }

    [JsonPropertyName("resourceGuardOperationRequests")]
    public List<string>? ResourceGuardOperationRequests { get; set; }
}
