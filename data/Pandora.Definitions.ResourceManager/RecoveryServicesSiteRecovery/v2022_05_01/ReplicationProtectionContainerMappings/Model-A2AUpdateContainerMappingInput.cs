using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectionContainerMappings;

[ValueForType("A2A")]
internal class A2AUpdateContainerMappingInputModel : ReplicationProviderSpecificUpdateContainerMappingInputModel
{
    [JsonPropertyName("agentAutoUpdateStatus")]
    public AgentAutoUpdateStatusConstant? AgentAutoUpdateStatus { get; set; }

    [JsonPropertyName("automationAccountArmId")]
    public string? AutomationAccountArmId { get; set; }

    [JsonPropertyName("automationAccountAuthenticationType")]
    public AutomationAccountAuthenticationTypeConstant? AutomationAccountAuthenticationType { get; set; }
}
