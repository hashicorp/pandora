using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.NetAppAccounts;

internal class Definition : ResourceDefinition
{
    public string Name => "NetAppAccounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccountsCreateOrUpdateOperation(),
        new AccountsDeleteOperation(),
        new AccountsGetOperation(),
        new AccountsListOperation(),
        new AccountsListBySubscriptionOperation(),
        new AccountsUpdateOperation(),
    };
}
