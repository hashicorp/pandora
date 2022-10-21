using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.ClusterPrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrincipalTypeConstant
{
    [Description("App")]
    App,

    [Description("Group")]
    Group,

    [Description("User")]
    User,
}
