using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.IncrementalRestorePoints;

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
