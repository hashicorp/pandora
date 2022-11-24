using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationJobs;

[ValueForType("FabricReplicationGroupTaskDetails")]
internal class FabricReplicationGroupTaskDetailsModel : JobTaskDetailsModel
{
    [JsonPropertyName("skippedReason")]
    public string? SkippedReason { get; set; }

    [JsonPropertyName("skippedReasonString")]
    public string? SkippedReasonString { get; set; }
}
