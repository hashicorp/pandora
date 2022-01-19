using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.DefaultAccount
{
    internal class Definition : ApiDefinition
    {
        public string Name => "DefaultAccount";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new RemoveOperation(),
            new SetOperation(),
        };
    }
}
