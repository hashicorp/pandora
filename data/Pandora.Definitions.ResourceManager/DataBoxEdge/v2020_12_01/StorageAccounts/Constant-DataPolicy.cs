using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataPolicyConstant
{
    [Description("Cloud")]
    Cloud,

    [Description("Local")]
    Local,
}
