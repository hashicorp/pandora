using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CognitiveServicesAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QuotaUsageStatusConstant
{
    [Description("Blocked")]
    Blocked,

    [Description("InOverage")]
    InOverage,

    [Description("Included")]
    Included,

    [Description("Unknown")]
    Unknown,
}
