using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.GlobalSchedules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnableStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
