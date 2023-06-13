using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.DatabaseRecommendedActions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsRetryableConstant
{
    [Description("No")]
    No,

    [Description("Yes")]
    Yes,
}
