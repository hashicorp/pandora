using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectableItems;


internal class DiskDetailsModel
{
    [JsonPropertyName("maxSizeMB")]
    public int? MaxSizeMB { get; set; }

    [JsonPropertyName("vhdId")]
    public string? VhdId { get; set; }

    [JsonPropertyName("vhdName")]
    public string? VhdName { get; set; }

    [JsonPropertyName("vhdType")]
    public string? VhdType { get; set; }
}
