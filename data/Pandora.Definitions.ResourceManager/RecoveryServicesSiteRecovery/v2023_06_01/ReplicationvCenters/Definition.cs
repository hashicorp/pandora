using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationvCenters;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationvCenters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationFabricsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthErrorCustomerResolvabilityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddVCenterRequestModel),
        typeof(AddVCenterRequestPropertiesModel),
        typeof(HealthErrorModel),
        typeof(InnerHealthErrorModel),
        typeof(UpdateVCenterRequestModel),
        typeof(UpdateVCenterRequestPropertiesModel),
        typeof(VCenterModel),
        typeof(VCenterPropertiesModel),
    };
}
