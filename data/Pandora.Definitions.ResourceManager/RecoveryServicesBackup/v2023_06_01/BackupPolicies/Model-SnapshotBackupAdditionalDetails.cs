using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.BackupPolicies;


internal class SnapshotBackupAdditionalDetailsModel
{
    [JsonPropertyName("instantRPDetails")]
    public string? InstantRPDetails { get; set; }

    [JsonPropertyName("instantRpRetentionRangeInDays")]
    public int? InstantRpRetentionRangeInDays { get; set; }

    [JsonPropertyName("userAssignedManagedIdentityDetails")]
    public UserAssignedManagedIdentityDetailsModel? UserAssignedManagedIdentityDetails { get; set; }
}
