using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.LabPlan;

internal class Definition : ResourceDefinition
{
    public string Name => "LabPlan";
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
        typeof(ConnectionTypeConstant),
        typeof(EnableStateConstant),
        typeof(ProvisioningStateConstant),
        typeof(ShutdownOnIdleModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoShutdownProfileModel),
        typeof(ConnectionProfileModel),
        typeof(LabPlanModel),
        typeof(LabPlanNetworkProfileModel),
        typeof(LabPlanPropertiesModel),
        typeof(LabPlanUpdateModel),
        typeof(LabPlanUpdatePropertiesModel),
        typeof(SupportInfoModel),
    };
}
