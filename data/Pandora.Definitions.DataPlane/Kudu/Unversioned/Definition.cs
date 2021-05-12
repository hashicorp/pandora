using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.Kudu.Unversioned
{
    public class Definition : ApiVersionDefinition
    {
        // NOTE: this is an magic string because the Kudu API is versionless
        public string ApiVersion => "unversioned";
        public bool Generate => true;
        public bool Preview => false;
        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Settings.Definition()
        };
    }
}