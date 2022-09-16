using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsSchemas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SensitivityLabelSourceConstant
{
    [Description("current")]
    Current,

    [Description("recommended")]
    Recommended,
}
