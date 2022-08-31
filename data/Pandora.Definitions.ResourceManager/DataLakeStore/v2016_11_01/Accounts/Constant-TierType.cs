using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TierTypeConstant
{
    [Description("Commitment_500TB")]
    CommitmentFiveHundredTB,

    [Description("Commitment_5PB")]
    CommitmentFivePB,

    [Description("Commitment_100TB")]
    CommitmentOneHundredTB,

    [Description("Commitment_1PB")]
    CommitmentOnePB,

    [Description("Commitment_1TB")]
    CommitmentOneTB,

    [Description("Commitment_10TB")]
    CommitmentOneZeroTB,

    [Description("Consumption")]
    Consumption,
}
