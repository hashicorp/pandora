using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01.ManagedClusters;


internal class SysctlConfigModel
{
    [JsonPropertyName("fsAioMaxNr")]
    public int? FsAioMaxNr { get; set; }

    [JsonPropertyName("fsFileMax")]
    public int? FsFileMax { get; set; }

    [JsonPropertyName("fsInotifyMaxUserWatches")]
    public int? FsInotifyMaxUserWatches { get; set; }

    [JsonPropertyName("fsNrOpen")]
    public int? FsNrOpen { get; set; }

    [JsonPropertyName("kernelThreadsMax")]
    public int? KernelThreadsMax { get; set; }

    [JsonPropertyName("netCoreNetdevMaxBacklog")]
    public int? NetCoreNetdevMaxBacklog { get; set; }

    [JsonPropertyName("netCoreOptmemMax")]
    public int? NetCoreOptmemMax { get; set; }

    [JsonPropertyName("netCoreRmemDefault")]
    public int? NetCoreRmemDefault { get; set; }

    [JsonPropertyName("netCoreRmemMax")]
    public int? NetCoreRmemMax { get; set; }

    [JsonPropertyName("netCoreSomaxconn")]
    public int? NetCoreSomaxconn { get; set; }

    [JsonPropertyName("netCoreWmemDefault")]
    public int? NetCoreWmemDefault { get; set; }

    [JsonPropertyName("netCoreWmemMax")]
    public int? NetCoreWmemMax { get; set; }

    [JsonPropertyName("netIpv4IpLocalPortRange")]
    public string? NetIPv4IPLocalPortRange { get; set; }

    [JsonPropertyName("netIpv4NeighDefaultGcThresh1")]
    public int? NetIPv4NeighDefaultGcThresh1 { get; set; }

    [JsonPropertyName("netIpv4NeighDefaultGcThresh2")]
    public int? NetIPv4NeighDefaultGcThresh2 { get; set; }

    [JsonPropertyName("netIpv4NeighDefaultGcThresh3")]
    public int? NetIPv4NeighDefaultGcThresh3 { get; set; }

    [JsonPropertyName("netIpv4TcpFinTimeout")]
    public int? NetIPv4TcpFinTimeout { get; set; }

    [JsonPropertyName("netIpv4TcpKeepaliveProbes")]
    public int? NetIPv4TcpKeepaliveProbes { get; set; }

    [JsonPropertyName("netIpv4TcpKeepaliveTime")]
    public int? NetIPv4TcpKeepaliveTime { get; set; }

    [JsonPropertyName("netIpv4TcpMaxSynBacklog")]
    public int? NetIPv4TcpMaxSynBacklog { get; set; }

    [JsonPropertyName("netIpv4TcpMaxTwBuckets")]
    public int? NetIPv4TcpMaxTwBuckets { get; set; }

    [JsonPropertyName("netIpv4TcpTwReuse")]
    public bool? NetIPv4TcpTwReuse { get; set; }

    [JsonPropertyName("netIpv4TcpkeepaliveIntvl")]
    public int? NetIPv4TcpkeepaliveIntvl { get; set; }

    [JsonPropertyName("netNetfilterNfConntrackBuckets")]
    public int? NetNetfilterNfConntrackBuckets { get; set; }

    [JsonPropertyName("netNetfilterNfConntrackMax")]
    public int? NetNetfilterNfConntrackMax { get; set; }

    [JsonPropertyName("vmMaxMapCount")]
    public int? VMMaxMapCount { get; set; }

    [JsonPropertyName("vmSwappiness")]
    public int? VMSwappiness { get; set; }

    [JsonPropertyName("vmVfsCachePressure")]
    public int? VMVfsCachePressure { get; set; }
}
