using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.Deviceupdates;

internal class Definition : ResourceDefinition
{
    public string Name => "Deviceupdates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccountsCreateOperation(),
        new AccountsDeleteOperation(),
        new AccountsGetOperation(),
        new AccountsHeadOperation(),
        new AccountsListByResourceGroupOperation(),
        new AccountsListBySubscriptionOperation(),
        new AccountsUpdateOperation(),
        new CheckNameAvailabilityOperation(),
        new InstancesCreateOperation(),
        new InstancesDeleteOperation(),
        new InstancesGetOperation(),
        new InstancesHeadOperation(),
        new InstancesListByAccountOperation(),
        new InstancesUpdateOperation(),
        new PrivateEndpointConnectionProxiesUpdatePrivateEndpointPropertiesOperation(),
        new PrivateEndpointConnectionProxiesValidateOperation(),
    };
}
