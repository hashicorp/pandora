using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.InstancePools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstancePoolLicenseTypeConstant
{
    [Description("BasePrice")]
    BasePrice,

    [Description("LicenseIncluded")]
    LicenseIncluded,
}
