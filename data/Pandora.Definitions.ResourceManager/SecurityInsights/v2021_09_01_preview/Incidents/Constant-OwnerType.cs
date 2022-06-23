using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Incidents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OwnerTypeConstant
{
    [Description("Group")]
    Group,

    [Description("Unknown")]
    Unknown,

    [Description("User")]
    User,
}
