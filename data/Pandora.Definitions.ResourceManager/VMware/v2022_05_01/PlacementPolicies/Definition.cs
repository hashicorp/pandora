using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PlacementPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "PlacementPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
        new VirtualMachinesRestrictMovementOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AffinityStrengthConstant),
        typeof(AffinityTypeConstant),
        typeof(AzureHybridBenefitTypeConstant),
        typeof(PlacementPolicyProvisioningStateConstant),
        typeof(PlacementPolicyStateConstant),
        typeof(PlacementPolicyTypeConstant),
        typeof(VirtualMachineRestrictMovementStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PlacementPolicyModel),
        typeof(PlacementPolicyPropertiesModel),
        typeof(PlacementPolicyUpdateModel),
        typeof(PlacementPolicyUpdatePropertiesModel),
        typeof(VMHostPlacementPolicyPropertiesModel),
        typeof(VMVMPlacementPolicyPropertiesModel),
        typeof(VirtualMachineRestrictMovementModel),
    };
}
