using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationFabrics;

[ValueForType("InMageRcm")]
internal class InMageRcmFabricSpecificDetailsModel : FabricSpecificDetailsModel
{
    [JsonPropertyName("agentDetails")]
    public List<AgentDetailsModel>? AgentDetails { get; set; }

    [JsonPropertyName("controlPlaneUri")]
    public string? ControlPlaneUri { get; set; }

    [JsonPropertyName("dataPlaneUri")]
    public string? DataPlaneUri { get; set; }

    [JsonPropertyName("dras")]
    public List<DraDetailsModel>? Dras { get; set; }

    [JsonPropertyName("marsAgents")]
    public List<MarsAgentDetailsModel>? MarsAgents { get; set; }

    [JsonPropertyName("physicalSiteId")]
    public string? PhysicalSiteId { get; set; }

    [JsonPropertyName("processServers")]
    public List<ProcessServerDetailsModel>? ProcessServers { get; set; }

    [JsonPropertyName("pushInstallers")]
    public List<PushInstallerDetailsModel>? PushInstallers { get; set; }

    [JsonPropertyName("rcmProxies")]
    public List<RcmProxyDetailsModel>? RcmProxies { get; set; }

    [JsonPropertyName("replicationAgents")]
    public List<ReplicationAgentDetailsModel>? ReplicationAgents { get; set; }

    [JsonPropertyName("reprotectAgents")]
    public List<ReprotectAgentDetailsModel>? ReprotectAgents { get; set; }

    [JsonPropertyName("serviceContainerId")]
    public string? ServiceContainerId { get; set; }

    [JsonPropertyName("serviceEndpoint")]
    public string? ServiceEndpoint { get; set; }

    [JsonPropertyName("serviceResourceId")]
    public string? ServiceResourceId { get; set; }

    [JsonPropertyName("sourceAgentIdentityDetails")]
    public IdentityProviderDetailsModel? SourceAgentIdentityDetails { get; set; }

    [JsonPropertyName("vmwareSiteId")]
    public string? VMwareSiteId { get; set; }
}
