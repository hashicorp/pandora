using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedInstanceLicenseTypeConstant
{
    [Description("BasePrice")]
    BasePrice,

    [Description("LicenseIncluded")]
    LicenseIncluded,
}
