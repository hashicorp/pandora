using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiPolicy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessIdNameConstant
{
    [Description("access")]
    Access,

    [Description("gitAccess")]
    GitAccess,
}
