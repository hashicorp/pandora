// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OpenNetworkAzureSecurityGroupFindingModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inboundPorts")]
    public InboundPortsModel? InboundPorts { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("securityGroup")]
    public AuthorizationSystemResourceModel? SecurityGroup { get; set; }

    [JsonPropertyName("virtualMachines")]
    public List<VirtualMachineDetailsModel>? VirtualMachines { get; set; }
}
