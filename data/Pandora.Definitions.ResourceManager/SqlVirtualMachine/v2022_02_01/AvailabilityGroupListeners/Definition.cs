using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.AvailabilityGroupListeners;

internal class Definition : ResourceDefinition
{
    public string Name => "AvailabilityGroupListeners";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByGroupOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CommitConstant),
        typeof(FailoverConstant),
        typeof(ReadableSecondaryConstant),
        typeof(RoleConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgConfigurationModel),
        typeof(AgReplicaModel),
        typeof(AvailabilityGroupListenerModel),
        typeof(AvailabilityGroupListenerPropertiesModel),
        typeof(LoadBalancerConfigurationModel),
        typeof(MultiSubnetIPConfigurationModel),
        typeof(PrivateIPAddressModel),
    };
}
