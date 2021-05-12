using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.Kudu.Unversioned.Settings
{
    internal class SettingsId : ResourceID
    {
        public string ID() => "/api/settings/{keyName}";
    }
}