using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{
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
}
