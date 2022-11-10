using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.CheckNameAvailability;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CheckNameAvailabilityReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
