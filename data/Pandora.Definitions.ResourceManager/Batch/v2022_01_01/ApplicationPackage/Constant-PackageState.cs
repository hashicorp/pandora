using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.ApplicationPackage;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PackageStateConstant
{
    [Description("Active")]
    Active,

    [Description("Pending")]
    Pending,
}
