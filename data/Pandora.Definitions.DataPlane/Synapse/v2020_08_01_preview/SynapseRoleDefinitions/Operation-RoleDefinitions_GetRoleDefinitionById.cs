using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.DataPlane.Synapse.v2020_08_01_preview.SynapseRoleDefinitions
{
    internal class RoleDefinitions_GetRoleDefinitionById : GetOperation
    {
        public override object? ResponseObject()
        {
            return new SynapseRoleDefinition();
        }
    }
}
