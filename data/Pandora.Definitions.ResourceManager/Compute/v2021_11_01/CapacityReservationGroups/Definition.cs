using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.CapacityReservationGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "CapacityReservationGroups";
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
        typeof(CapacityReservationGroupInstanceViewTypesConstant),
        typeof(ExpandTypesForGetCapacityReservationGroupsConstant),
        typeof(StatusLevelTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapacityReservationGroupModel),
        typeof(CapacityReservationGroupInstanceViewModel),
        typeof(CapacityReservationGroupPropertiesModel),
        typeof(CapacityReservationGroupUpdateModel),
        typeof(CapacityReservationInstanceViewWithNameModel),
        typeof(CapacityReservationUtilizationModel),
        typeof(InstanceViewStatusModel),
        typeof(SubResourceReadOnlyModel),
    };
}
