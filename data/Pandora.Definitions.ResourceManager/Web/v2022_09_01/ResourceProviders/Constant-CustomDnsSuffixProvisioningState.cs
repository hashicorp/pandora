using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomDnsSuffixProvisioningStateConstant
{
    [Description("Degraded")]
    Degraded,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Succeeded")]
    Succeeded,
}
