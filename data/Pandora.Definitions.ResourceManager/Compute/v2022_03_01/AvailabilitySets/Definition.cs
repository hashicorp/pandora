using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.AvailabilitySets;

internal class Definition : ResourceDefinition
{
    public string Name => "AvailabilitySets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAvailableSizesOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(StatusLevelTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvailabilitySetModel),
        typeof(AvailabilitySetPropertiesModel),
        typeof(AvailabilitySetUpdateModel),
        typeof(InstanceViewStatusModel),
        typeof(SkuModel),
        typeof(SubResourceModel),
        typeof(VirtualMachineSizeModel),
        typeof(VirtualMachineSizeListResultModel),
    };
}
