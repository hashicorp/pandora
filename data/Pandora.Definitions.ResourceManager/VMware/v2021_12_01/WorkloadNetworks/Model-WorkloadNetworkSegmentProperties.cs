using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.WorkloadNetworks;


internal class WorkloadNetworkSegmentPropertiesModel
{
    [JsonPropertyName("connectedGateway")]
    public string? ConnectedGateway { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("portVif")]
    public List<WorkloadNetworkSegmentPortVifModel>? PortVif { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkloadNetworkSegmentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("status")]
    public SegmentStatusEnumConstant? Status { get; set; }

    [JsonPropertyName("subnet")]
    public WorkloadNetworkSegmentSubnetModel? Subnet { get; set; }
}
