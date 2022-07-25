using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChownModeConstant
{
    [Description("Restricted")]
    Restricted,

    [Description("Unrestricted")]
    Unrestricted,
}
