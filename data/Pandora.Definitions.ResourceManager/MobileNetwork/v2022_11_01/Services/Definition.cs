using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.Services;

internal class Definition : ResourceDefinition
{
    public string Name => "Services";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByMobileNetworkOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PreemptionCapabilityConstant),
        typeof(PreemptionVulnerabilityConstant),
        typeof(ProvisioningStateConstant),
        typeof(SdfDirectionConstant),
        typeof(TrafficControlPermissionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmbrModel),
        typeof(PccRuleConfigurationModel),
        typeof(PccRuleQosPolicyModel),
        typeof(QosPolicyModel),
        typeof(ServiceModel),
        typeof(ServiceDataFlowTemplateModel),
        typeof(ServicePropertiesFormatModel),
    };
}
