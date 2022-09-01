using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RemoteApplicationTypeConstant
{
    [Description("InBuilt")]
    InBuilt,

    [Description("MsixApplication")]
    MsixApplication,
}
