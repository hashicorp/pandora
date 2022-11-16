using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01.CognitiveServicesAccounts;

internal class Definition : ResourceDefinition
{
    public string Name => "CognitiveServicesAccounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccountsCreateOperation(),
        new AccountsDeleteOperation(),
        new AccountsGetOperation(),
        new AccountsListOperation(),
        new AccountsListByResourceGroupOperation(),
        new AccountsListKeysOperation(),
        new AccountsListModelsOperation(),
        new AccountsListSkusOperation(),
        new AccountsListUsagesOperation(),
        new AccountsRegenerateKeyOperation(),
        new AccountsUpdateOperation(),
        new CheckDomainAvailabilityOperation(),
        new CheckSkuAvailabilityOperation(),
        new DeletedAccountsGetOperation(),
        new DeletedAccountsListOperation(),
        new DeletedAccountsPurgeOperation(),
        new ResourceSkusListOperation(),
    };
}
