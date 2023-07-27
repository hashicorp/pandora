using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.UserSubscription;

internal class Definition : ResourceDefinition
{
    public string Name => "UserSubscription";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SubscriptionStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SubscriptionContractModel),
        typeof(SubscriptionContractPropertiesModel),
    };
}
