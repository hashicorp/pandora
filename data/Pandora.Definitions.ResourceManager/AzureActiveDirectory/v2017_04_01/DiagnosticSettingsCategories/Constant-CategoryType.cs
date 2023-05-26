using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2017_04_01.DiagnosticSettingsCategories;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoryTypeConstant
{
    [Description("Logs")]
    Logs,
}
