using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
