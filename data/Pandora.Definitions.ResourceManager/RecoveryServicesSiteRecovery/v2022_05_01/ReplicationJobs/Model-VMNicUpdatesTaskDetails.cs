using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationJobs;

[ValueForType("VmNicUpdatesTaskDetails")]
internal class VMNicUpdatesTaskDetailsModel : TaskTypeDetailsModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nicId")]
    public string? NicId { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }
}
