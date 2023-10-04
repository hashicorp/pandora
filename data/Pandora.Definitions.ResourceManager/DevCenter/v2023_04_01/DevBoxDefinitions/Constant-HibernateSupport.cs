using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.DevBoxDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HibernateSupportConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
