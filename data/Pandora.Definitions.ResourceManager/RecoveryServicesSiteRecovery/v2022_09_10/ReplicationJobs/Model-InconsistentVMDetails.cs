using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationJobs;


internal class InconsistentVMDetailsModel
{
    [JsonPropertyName("cloudName")]
    public string? CloudName { get; set; }

    [JsonPropertyName("details")]
    public List<string>? Details { get; set; }

    [JsonPropertyName("errorIds")]
    public List<string>? ErrorIds { get; set; }

    [JsonPropertyName("vmName")]
    public string? VirtualMachineName { get; set; }
}
