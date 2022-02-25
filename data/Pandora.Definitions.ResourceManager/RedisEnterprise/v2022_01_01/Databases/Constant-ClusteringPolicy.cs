using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusteringPolicyConstant
{
    [Description("EnterpriseCluster")]
    EnterpriseCluster,

    [Description("OSSCluster")]
    OSSCluster,
}
