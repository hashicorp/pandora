using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngressClientCertificateModeConstant
{
    [Description("accept")]
    Accept,

    [Description("ignore")]
    Ignore,

    [Description("require")]
    Require,
}
