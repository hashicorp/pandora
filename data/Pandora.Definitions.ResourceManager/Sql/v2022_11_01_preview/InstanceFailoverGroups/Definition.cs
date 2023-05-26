using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.InstanceFailoverGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "InstanceFailoverGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FailoverOperation(),
        new ForceFailoverAllowDataLossOperation(),
        new GetOperation(),
        new ListByLocationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InstanceFailoverGroupReplicationRoleConstant),
        typeof(ReadOnlyEndpointFailoverPolicyConstant),
        typeof(ReadWriteEndpointFailoverPolicyConstant),
        typeof(SecondaryInstanceTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(InstanceFailoverGroupModel),
        typeof(InstanceFailoverGroupPropertiesModel),
        typeof(InstanceFailoverGroupReadOnlyEndpointModel),
        typeof(InstanceFailoverGroupReadWriteEndpointModel),
        typeof(ManagedInstancePairInfoModel),
        typeof(PartnerRegionInfoModel),
    };
}
