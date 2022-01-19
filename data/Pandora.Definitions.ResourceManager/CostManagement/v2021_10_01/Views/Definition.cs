using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views
{
    internal class Definition : ApiDefinition
    {
        public string Name => "Views";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new CreateOrUpdateByScopeOperation(),
            new DeleteOperation(),
            new DeleteByScopeOperation(),
            new GetOperation(),
            new GetByScopeOperation(),
            new ListOperation(),
            new ListByScopeOperation(),
        };
    }
}
