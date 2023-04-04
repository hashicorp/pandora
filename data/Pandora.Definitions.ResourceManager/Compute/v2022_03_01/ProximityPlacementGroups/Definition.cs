using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.ProximityPlacementGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "ProximityPlacementGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProximityPlacementGroupTypeConstant),
        typeof(StatusLevelTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(InstanceViewStatusModel),
        typeof(ProximityPlacementGroupModel),
        typeof(ProximityPlacementGroupPropertiesModel),
        typeof(ProximityPlacementGroupPropertiesIntentModel),
        typeof(SubResourceWithColocationStatusModel),
        typeof(UpdateResourceModel),
    };
}
