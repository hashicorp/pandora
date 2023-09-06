using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_07_01.SubscriptionFeatureRegistrations;

internal class Definition : ResourceDefinition
{
    public string Name => "SubscriptionFeatureRegistrations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListAllBySubscriptionOperation(),
        new ListBySubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SubscriptionFeatureRegistrationApprovalTypeConstant),
        typeof(SubscriptionFeatureRegistrationStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizationProfileModel),
        typeof(SubscriptionFeatureRegistrationModel),
        typeof(SubscriptionFeatureRegistrationPropertiesModel),
    };
}
