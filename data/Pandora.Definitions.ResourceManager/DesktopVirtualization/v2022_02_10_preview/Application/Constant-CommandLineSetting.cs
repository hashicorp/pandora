using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommandLineSettingConstant
{
    [Description("Allow")]
    Allow,

    [Description("DoNotAllow")]
    DoNotAllow,

    [Description("Require")]
    Require,
}
