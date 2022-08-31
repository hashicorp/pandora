using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2021_11_30.DedicatedHsms;

internal class Definition : ResourceDefinition
{
    public string Name => "DedicatedHsms";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DedicatedHsmCreateOrUpdateOperation(),
        new DedicatedHsmDeleteOperation(),
        new DedicatedHsmGetOperation(),
        new DedicatedHsmListByResourceGroupOperation(),
        new DedicatedHsmListBySubscriptionOperation(),
        new DedicatedHsmListOutboundNetworkDependenciesEndpointsOperation(),
        new DedicatedHsmUpdateOperation(),
    };
}
