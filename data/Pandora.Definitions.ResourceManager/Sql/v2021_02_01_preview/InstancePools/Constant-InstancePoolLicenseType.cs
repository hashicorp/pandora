using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.InstancePools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstancePoolLicenseTypeConstant
{
    [Description("BasePrice")]
    BasePrice,

    [Description("LicenseIncluded")]
    LicenseIncluded,
}
