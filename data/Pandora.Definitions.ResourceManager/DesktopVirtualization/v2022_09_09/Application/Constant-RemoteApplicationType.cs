using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RemoteApplicationTypeConstant
{
    [Description("InBuilt")]
    InBuilt,

    [Description("MsixApplication")]
    MsixApplication,
}
