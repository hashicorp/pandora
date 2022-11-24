using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("InMageRcm")]
internal class InMageRcmReprotectInputModel : ReverseReplicationProviderSpecificInputModel
{
    [JsonPropertyName("datastoreName")]
    [Required]
    public string DatastoreName { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    [Required]
    public string LogStorageAccountId { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("reprotectAgentId")]
    [Required]
    public string ReprotectAgentId { get; set; }
}
