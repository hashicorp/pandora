using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.TenantAccess;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessIdNameConstant
{
    [Description("access")]
    Access,

    [Description("gitAccess")]
    GitAccess,
}
