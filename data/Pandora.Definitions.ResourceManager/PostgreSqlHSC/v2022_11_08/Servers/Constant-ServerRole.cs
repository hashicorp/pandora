using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerRoleConstant
{
    [Description("Coordinator")]
    Coordinator,

    [Description("Worker")]
    Worker,
}
