using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationAppliances;


internal class InMageRcmApplianceDetailsModel
{
    [JsonPropertyName("dra")]
    public DraDetailsModel? Dra { get; set; }

    [JsonPropertyName("fabricArmId")]
    public string? FabricArmId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("marsAgent")]
    public MarsAgentDetailsModel? MarsAgent { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("processServer")]
    public ProcessServerDetailsModel? ProcessServer { get; set; }

    [JsonPropertyName("pushInstaller")]
    public PushInstallerDetailsModel? PushInstaller { get; set; }

    [JsonPropertyName("rcmProxy")]
    public RcmProxyDetailsModel? RcmProxy { get; set; }

    [JsonPropertyName("replicationAgent")]
    public ReplicationAgentDetailsModel? ReplicationAgent { get; set; }

    [JsonPropertyName("reprotectAgent")]
    public ReprotectAgentDetailsModel? ReprotectAgent { get; set; }

    [JsonPropertyName("switchProviderBlockingErrorDetails")]
    public List<InMageRcmFabricSwitchProviderBlockingErrorDetailsModel>? SwitchProviderBlockingErrorDetails { get; set; }
}
