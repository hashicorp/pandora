using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.BatchManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NameAvailabilityReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
