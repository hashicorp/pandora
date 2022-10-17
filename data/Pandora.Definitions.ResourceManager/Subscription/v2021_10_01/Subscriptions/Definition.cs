using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

internal class Definition : ResourceDefinition
{
    public string Name => "Subscriptions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AliasCreateOperation(),
        new AliasDeleteOperation(),
        new AliasGetOperation(),
        new AliasListOperation(),
        new BillingAccountGetPolicyOperation(),
        new SubscriptionAcceptOwnershipOperation(),
        new SubscriptionAcceptOwnershipStatusOperation(),
        new SubscriptionCancelOperation(),
        new SubscriptionEnableOperation(),
        new SubscriptionPolicyAddUpdatePolicyForTenantOperation(),
        new SubscriptionPolicyGetPolicyForTenantOperation(),
        new SubscriptionPolicyListPolicyForTenantOperation(),
        new SubscriptionRenameOperation(),
    };
}
