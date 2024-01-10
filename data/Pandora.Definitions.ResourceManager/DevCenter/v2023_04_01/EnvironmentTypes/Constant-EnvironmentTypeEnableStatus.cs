using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.EnvironmentTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnvironmentTypeEnableStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
