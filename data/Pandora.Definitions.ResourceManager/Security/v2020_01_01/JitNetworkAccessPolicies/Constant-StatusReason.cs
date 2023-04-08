using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.JitNetworkAccessPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusReasonConstant
{
    [Description("Expired")]
    Expired,

    [Description("NewerRequestInitiated")]
    NewerRequestInitiated,

    [Description("UserRequested")]
    UserRequested,
}
