using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.IncrementalRestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkAccessPolicyConstant
{
    [Description("AllowAll")]
    AllowAll,

    [Description("AllowPrivate")]
    AllowPrivate,

    [Description("DenyAll")]
    DenyAll,
}
