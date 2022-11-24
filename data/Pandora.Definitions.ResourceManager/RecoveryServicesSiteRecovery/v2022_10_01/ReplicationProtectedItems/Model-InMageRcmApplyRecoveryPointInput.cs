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
internal class InMageRcmApplyRecoveryPointInputModel : ApplyRecoveryPointProviderSpecificInputModel
{
    [JsonPropertyName("recoveryPointId")]
    [Required]
    public string RecoveryPointId { get; set; }
}
