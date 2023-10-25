using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DataMaskingPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataMaskingStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
