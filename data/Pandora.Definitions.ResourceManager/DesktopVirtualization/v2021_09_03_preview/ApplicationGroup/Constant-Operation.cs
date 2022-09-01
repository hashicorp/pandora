using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.ApplicationGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationConstant
{
    [Description("Complete")]
    Complete,

    [Description("Hide")]
    Hide,

    [Description("Revoke")]
    Revoke,

    [Description("Start")]
    Start,

    [Description("Unhide")]
    Unhide,
}
