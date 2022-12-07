using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.UpdateSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SeverityConstant
{
    [Description("Critical")]
    Critical,

    [Description("Hidden")]
    Hidden,

    [Description("Informational")]
    Informational,

    [Description("Warning")]
    Warning,
}
