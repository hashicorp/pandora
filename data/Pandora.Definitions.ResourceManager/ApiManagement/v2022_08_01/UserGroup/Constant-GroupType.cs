using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.UserGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupTypeConstant
{
    [Description("custom")]
    Custom,

    [Description("external")]
    External,

    [Description("system")]
    System,
}
