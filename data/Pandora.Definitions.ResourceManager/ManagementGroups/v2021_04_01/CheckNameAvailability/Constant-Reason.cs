using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.CheckNameAvailability;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
