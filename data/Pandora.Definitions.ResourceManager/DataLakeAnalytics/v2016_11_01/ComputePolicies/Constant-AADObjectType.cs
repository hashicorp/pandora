using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.ComputePolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AADObjectTypeConstant
{
    [Description("Group")]
    Group,

    [Description("ServicePrincipal")]
    ServicePrincipal,

    [Description("User")]
    User,
}
