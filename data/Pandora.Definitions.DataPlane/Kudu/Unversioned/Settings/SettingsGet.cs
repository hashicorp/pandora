using System.Collections.Generic;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.DataPlane.Kudu.Unversioned.Settings
{
    public class SettingsGet : GetOperation
    {
        public override object? ResponseObject()
        {
            return new Dictionary<string, string>();
        }
    }
}