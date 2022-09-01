using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.Application;

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
