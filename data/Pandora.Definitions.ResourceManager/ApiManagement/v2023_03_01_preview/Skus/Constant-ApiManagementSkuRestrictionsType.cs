using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Skus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiManagementSkuRestrictionsTypeConstant
{
    [Description("Location")]
    Location,

    [Description("Zone")]
    Zone,
}
