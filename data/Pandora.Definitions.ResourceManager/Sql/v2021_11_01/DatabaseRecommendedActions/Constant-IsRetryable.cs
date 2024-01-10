using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DatabaseRecommendedActions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsRetryableConstant
{
    [Description("No")]
    No,

    [Description("Yes")]
    Yes,
}
