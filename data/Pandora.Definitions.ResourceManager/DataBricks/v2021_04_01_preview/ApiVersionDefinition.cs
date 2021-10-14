using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-04-01-preview";
        public bool Preview => true;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new DELETE.Definition(),
            new GET.Definition(),
            new PUT.Definition(),
            new VNetPeering.Definition(),
            new Workspaces.Definition(),
        };
    }
}
