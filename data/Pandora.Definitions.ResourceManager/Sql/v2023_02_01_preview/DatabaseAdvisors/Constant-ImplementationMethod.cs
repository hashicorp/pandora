using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DatabaseAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImplementationMethodConstant
{
    [Description("AzurePowerShell")]
    AzurePowerShell,

    [Description("TSql")]
    TSql,
}
