using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.JitNetworkAccessPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Initiated")]
    Initiated,

    [Description("Revoked")]
    Revoked,
}
