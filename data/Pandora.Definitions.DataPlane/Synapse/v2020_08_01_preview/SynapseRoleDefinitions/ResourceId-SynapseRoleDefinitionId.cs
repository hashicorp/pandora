using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.Synapse.v2020_08_01_preview.SynapseRoleDefinitions
{
	internal class SynapseRoleDefinitionId : ResourceID
	{
        public string ID() => "/roleDefinitions/{roleDefinitionId}";
	}
}
