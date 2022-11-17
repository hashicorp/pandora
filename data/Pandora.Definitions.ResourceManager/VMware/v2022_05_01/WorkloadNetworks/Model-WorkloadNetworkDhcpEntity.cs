using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.WorkloadNetworks;


internal abstract class WorkloadNetworkDhcpEntityModel
{
    [JsonPropertyName("dhcpType")]
    [ProvidesTypeHint]
    [Required]
    public DhcpTypeEnumConstant DhcpType { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkloadNetworkDhcpProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("segments")]
    public List<string>? Segments { get; set; }
}
