using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiPolicy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyExportFormatConstant
{
    [Description("rawxml")]
    Rawxml,

    [Description("xml")]
    Xml,
}
