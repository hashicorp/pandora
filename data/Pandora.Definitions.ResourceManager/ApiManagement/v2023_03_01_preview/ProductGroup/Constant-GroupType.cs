using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ProductGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupTypeConstant
{
    [Description("custom")]
    Custom,

    [Description("external")]
    External,

    [Description("system")]
    System,
}
