using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.FailoverGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "FailoverGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FailoverOperation(),
        new ForceFailoverAllowDataLossOperation(),
        new GetOperation(),
        new ListByServerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FailoverGroupReplicationRoleConstant),
        typeof(ReadOnlyEndpointFailoverPolicyConstant),
        typeof(ReadWriteEndpointFailoverPolicyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FailoverGroupModel),
        typeof(FailoverGroupPropertiesModel),
        typeof(FailoverGroupReadOnlyEndpointModel),
        typeof(FailoverGroupReadWriteEndpointModel),
        typeof(FailoverGroupUpdateModel),
        typeof(FailoverGroupUpdatePropertiesModel),
        typeof(PartnerInfoModel),
    };
}
