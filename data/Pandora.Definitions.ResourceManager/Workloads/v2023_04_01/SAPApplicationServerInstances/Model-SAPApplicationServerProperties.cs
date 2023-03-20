using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPApplicationServerInstances;


internal class SAPApplicationServerPropertiesModel
{
    [JsonPropertyName("errors")]
    public SAPVirtualInstanceErrorModel? Errors { get; set; }

    [JsonPropertyName("gatewayPort")]
    public int? GatewayPort { get; set; }

    [JsonPropertyName("health")]
    public SAPHealthStateConstant? Health { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("icmHttpPort")]
    public int? IcmHTTPPort { get; set; }

    [JsonPropertyName("icmHttpsPort")]
    public int? IcmHTTPSPort { get; set; }

    [JsonPropertyName("instanceNo")]
    public string? InstanceNo { get; set; }

    [JsonPropertyName("kernelPatch")]
    public string? KernelPatch { get; set; }

    [JsonPropertyName("kernelVersion")]
    public string? KernelVersion { get; set; }

    [JsonPropertyName("loadBalancerDetails")]
    public LoadBalancerDetailsModel? LoadBalancerDetails { get; set; }

    [JsonPropertyName("provisioningState")]
    public SapVirtualInstanceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public SAPVirtualInstanceStatusConstant? Status { get; set; }

    [JsonPropertyName("subnet")]
    public string? Subnet { get; set; }

    [JsonPropertyName("vmDetails")]
    public List<ApplicationServerVMDetailsModel>? VMDetails { get; set; }
}
