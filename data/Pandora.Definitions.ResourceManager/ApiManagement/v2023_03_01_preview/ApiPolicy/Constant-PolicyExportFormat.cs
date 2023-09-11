using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiPolicy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyExportFormatConstant
{
    [Description("rawxml")]
    Rawxml,

    [Description("xml")]
    Xml,
}
