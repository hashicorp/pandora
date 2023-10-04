using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.CheckNameAvailability;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CheckNameAvailabilityReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
