using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "70626b932d16a97361673e0bcba7570284fe0813" 

        public string ApiVersion => "2018-09-01-preview";
        public string Name => "CustomResourceProvider";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new UpdateOperation(),
        };
    }
}
