using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.JitRequests;

internal class Definition : ResourceDefinition
{
    public string Name => "JitRequests";
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
        typeof(JitRequestStateConstant),
        typeof(JitSchedulingTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationClientDetailsModel),
        typeof(JitAuthorizationPoliciesModel),
        typeof(JitRequestDefinitionModel),
        typeof(JitRequestDefinitionListResultModel),
        typeof(JitRequestPatchableModel),
        typeof(JitRequestPropertiesModel),
        typeof(JitSchedulingPolicyModel),
    };
}
