using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HighlyAvailableConstant
{
    [Description("No")]
    No,

    [Description("Unknown")]
    Unknown,

    [Description("Yes")]
    Yes,
}
