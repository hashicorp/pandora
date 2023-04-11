using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.ManagedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedHsmSkuNameConstant
{
    [Description("Custom_B6")]
    CustomBSix,

    [Description("Custom_B32")]
    CustomBThreeTwo,

    [Description("Standard_B1")]
    StandardBOne,
}
