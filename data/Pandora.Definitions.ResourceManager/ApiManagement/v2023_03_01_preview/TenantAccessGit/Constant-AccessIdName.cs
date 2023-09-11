using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.TenantAccessGit;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessIdNameConstant
{
    [Description("access")]
    Access,

    [Description("gitAccess")]
    GitAccess,
}
