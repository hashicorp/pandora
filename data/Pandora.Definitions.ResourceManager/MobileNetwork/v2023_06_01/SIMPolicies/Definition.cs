using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.SIMPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "SIMPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByMobileNetworkOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PduSessionTypeConstant),
        typeof(PreemptionCapabilityConstant),
        typeof(PreemptionVulnerabilityConstant),
        typeof(ProvisioningStateConstant),
        typeof(SiteProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmbrModel),
        typeof(DataNetworkConfigurationModel),
        typeof(DataNetworkResourceIdModel),
        typeof(ServiceResourceIdModel),
        typeof(SimPolicyModel),
        typeof(SimPolicyPropertiesFormatModel),
        typeof(SliceConfigurationModel),
        typeof(SliceResourceIdModel),
    };
}
