using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkFunction.v2022_08_01.CollectorPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EmissionTypeConstant
{
    [Description("IPFIX")]
    IPFIX,
}
