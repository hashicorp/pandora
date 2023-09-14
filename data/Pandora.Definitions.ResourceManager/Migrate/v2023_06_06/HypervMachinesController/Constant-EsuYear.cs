using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervMachinesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EsuYearConstant
{
    [Description("FirstYear")]
    FirstYear,

    [Description("SecondYear")]
    SecondYear,

    [Description("ThirdYear")]
    ThirdYear,

    [Description("Unknown")]
    Unknown,

    [Description("UpgradeYear")]
    UpgradeYear,
}
