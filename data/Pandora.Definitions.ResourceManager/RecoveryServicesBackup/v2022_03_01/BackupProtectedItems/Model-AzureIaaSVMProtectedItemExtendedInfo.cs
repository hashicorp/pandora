using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectedItems;


internal class AzureIaaSVMProtectedItemExtendedInfoModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("oldestRecoveryPoint")]
    public DateTime? OldestRecoveryPoint { get; set; }

    [JsonPropertyName("policyInconsistent")]
    public bool? PolicyInconsistent { get; set; }

    [JsonPropertyName("recoveryPointCount")]
    public int? RecoveryPointCount { get; set; }
}
