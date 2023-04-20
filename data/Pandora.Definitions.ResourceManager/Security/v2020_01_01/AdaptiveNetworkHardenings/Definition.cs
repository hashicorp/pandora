using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.AdaptiveNetworkHardenings;

internal class Definition : ResourceDefinition
{
    public string Name => "AdaptiveNetworkHardenings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EnforceOperation(),
        new GetOperation(),
        new ListByExtendedResourceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DirectionConstant),
        typeof(TransportProtocolConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdaptiveNetworkHardeningModel),
        typeof(AdaptiveNetworkHardeningEnforceRequestModel),
        typeof(AdaptiveNetworkHardeningPropertiesModel),
        typeof(EffectiveNetworkSecurityGroupsModel),
        typeof(RuleModel),
    };
}
