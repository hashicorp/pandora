using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.EventHubs;


internal class RetentionDescriptionModel
{
    [JsonPropertyName("cleanupPolicy")]
    public CleanupPolicyRetentionDescriptionConstant? CleanupPolicy { get; set; }

    [JsonPropertyName("retentionTimeInHours")]
    public int? RetentionTimeInHours { get; set; }

    [JsonPropertyName("tombstoneRetentionTimeInHours")]
    public int? TombstoneRetentionTimeInHours { get; set; }
}
