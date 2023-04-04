using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.AgentPools;

internal class Definition : ResourceDefinition
{
    public string Name => "AgentPools";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AbortLatestOperationOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAvailableAgentPoolVersionsOperation(),
        new GetUpgradeProfileOperation(),
        new ListOperation(),
        new UpgradeNodeImageVersionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AgentPoolModeConstant),
        typeof(AgentPoolTypeConstant),
        typeof(CodeConstant),
        typeof(GPUInstanceProfileConstant),
        typeof(KubeletDiskTypeConstant),
        typeof(OSDiskTypeConstant),
        typeof(OSSKUConstant),
        typeof(OSTypeConstant),
        typeof(ProtocolConstant),
        typeof(ScaleDownModeConstant),
        typeof(ScaleSetEvictionPolicyConstant),
        typeof(ScaleSetPriorityConstant),
        typeof(WorkloadRuntimeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgentPoolModel),
        typeof(AgentPoolAvailableVersionsModel),
        typeof(AgentPoolAvailableVersionsPropertiesModel),
        typeof(AgentPoolAvailableVersionsPropertiesAgentPoolVersionsInlinedModel),
        typeof(AgentPoolNetworkProfileModel),
        typeof(AgentPoolUpgradeProfileModel),
        typeof(AgentPoolUpgradeProfilePropertiesModel),
        typeof(AgentPoolUpgradeProfilePropertiesUpgradesInlinedModel),
        typeof(AgentPoolUpgradeSettingsModel),
        typeof(AgentPoolWindowsProfileModel),
        typeof(CreationDataModel),
        typeof(IPTagModel),
        typeof(KubeletConfigModel),
        typeof(LinuxOSConfigModel),
        typeof(ManagedClusterAgentPoolProfilePropertiesModel),
        typeof(PortRangeModel),
        typeof(PowerStateModel),
        typeof(SysctlConfigModel),
    };
}
