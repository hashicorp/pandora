using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Skus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiManagementSkuRestrictionsTypeConstant
{
    [Description("Location")]
    Location,

    [Description("Zone")]
    Zone,
}
