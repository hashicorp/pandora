using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DatabaseRecommendedActions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImplementationMethodConstant
{
    [Description("AzurePowerShell")]
    AzurePowerShell,

    [Description("TSql")]
    TSql,
}
