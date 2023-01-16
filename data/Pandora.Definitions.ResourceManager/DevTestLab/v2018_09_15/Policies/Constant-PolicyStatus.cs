using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Policies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
