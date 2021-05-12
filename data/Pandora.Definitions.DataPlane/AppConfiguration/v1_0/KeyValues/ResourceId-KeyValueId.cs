using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0.KeyValues
{
	internal class KeyValueId : ResourceID
	{
        public string ID() => "/kv/{key}";
	}
}
