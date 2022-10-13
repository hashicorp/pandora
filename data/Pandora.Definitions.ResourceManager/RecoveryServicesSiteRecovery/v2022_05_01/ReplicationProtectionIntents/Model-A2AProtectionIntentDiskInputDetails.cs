using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectionIntents;


internal class A2AProtectionIntentDiskInputDetailsModel
{
    [JsonPropertyName("diskUri")]
    [Required]
    public string DiskUri { get; set; }

    [JsonPropertyName("primaryStagingStorageAccountCustomInput")]
    public StorageAccountCustomDetailsModel? PrimaryStagingStorageAccountCustomInput { get; set; }

    [JsonPropertyName("recoveryAzureStorageAccountCustomInput")]
    public StorageAccountCustomDetailsModel? RecoveryAzureStorageAccountCustomInput { get; set; }
}
