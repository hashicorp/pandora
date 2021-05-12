using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.Kudu.Unversioned.Settings
{
    public class Definition : ApiDefinition
    {
        public string ApiVersion => "unversioned";
        public string Name => "settings";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new SettingsGet()
        };

        public ResourceID ResourceId => new SettingsId();
    }
}