using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerWorkspaceFeatureConstant
{
    [Description("Connected")]
    Connected,

    [Description("Disconnected")]
    Disconnected,
}
