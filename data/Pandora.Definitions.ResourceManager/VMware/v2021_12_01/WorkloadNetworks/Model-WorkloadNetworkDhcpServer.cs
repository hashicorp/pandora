using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.WorkloadNetworks;

[ValueForType("SERVER")]
internal class WorkloadNetworkDhcpServerModel : WorkloadNetworkDhcpEntityModel
{
    [JsonPropertyName("leaseTime")]
    public int? LeaseTime { get; set; }

    [JsonPropertyName("serverAddress")]
    public string? ServerAddress { get; set; }
}
