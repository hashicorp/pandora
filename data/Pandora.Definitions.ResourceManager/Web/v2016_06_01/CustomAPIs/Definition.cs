using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "CustomAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CustomApisCreateOrUpdateOperation(),
        new CustomApisDeleteOperation(),
        new CustomApisExtractApiDefinitionFromWsdlOperation(),
        new CustomApisGetOperation(),
        new CustomApisListOperation(),
        new CustomApisListByResourceGroupOperation(),
        new CustomApisListWsdlInterfacesOperation(),
        new CustomApisMoveOperation(),
        new CustomApisUpdateOperation(),
    };
}
