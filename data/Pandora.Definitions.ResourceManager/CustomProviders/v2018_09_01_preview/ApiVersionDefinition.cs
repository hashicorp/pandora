using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2018-09-01-preview";
        public bool Preview => true;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Associations.Definition(),
            new CustomResourceProvider.Definition(),
        };
    }
}
