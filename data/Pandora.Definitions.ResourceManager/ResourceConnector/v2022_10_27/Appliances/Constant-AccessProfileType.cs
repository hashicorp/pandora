using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ResourceConnector.v2022_10_27.Appliances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessProfileTypeConstant
{
    [Description("clusterCustomerUser")]
    ClusterCustomerUser,

    [Description("clusterUser")]
    ClusterUser,
}
