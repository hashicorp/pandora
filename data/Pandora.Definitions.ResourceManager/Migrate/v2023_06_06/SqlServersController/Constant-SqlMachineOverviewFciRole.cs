using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlServersController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlMachineOverviewFciRoleConstant
{
    [Description("ActiveNode")]
    ActiveNode,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("PossibleOwnerNode")]
    PossibleOwnerNode,

    [Description("Unknown")]
    Unknown,
}
