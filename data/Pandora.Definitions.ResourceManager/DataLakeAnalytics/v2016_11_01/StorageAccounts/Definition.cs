using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.StorageAccounts
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "StorageAccounts";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new AddOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new GetStorageContainerOperation(),
            new ListByAccountOperation(),
            new ListSasTokensOperation(),
            new ListStorageContainersOperation(),
            new UpdateOperation(),
        };
    }
}
