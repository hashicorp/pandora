using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.Lots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OrgTypeConstant
{
    [Description("Contributor")]
    Contributor,

    [Description("Primary")]
    Primary,
}
