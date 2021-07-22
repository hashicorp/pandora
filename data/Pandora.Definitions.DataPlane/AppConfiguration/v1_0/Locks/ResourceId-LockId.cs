using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0.Locks
{
    internal class LockId : ResourceID
    {
        public string ID() => "/locks/{key}";
    }
}
