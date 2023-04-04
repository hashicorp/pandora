using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachineGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "SqlVirtualMachineGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ClusterConfigurationConstant),
        typeof(ClusterManagerTypeConstant),
        typeof(ClusterSubnetTypeConstant),
        typeof(ScaleTypeConstant),
        typeof(SqlVMGroupImageSkuConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SqlVirtualMachineGroupModel),
        typeof(SqlVirtualMachineGroupPropertiesModel),
        typeof(SqlVirtualMachineGroupUpdateModel),
        typeof(WsfcDomainProfileModel),
    };
}
