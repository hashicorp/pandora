using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TierTypeConstant
{
    [Description("Commitment_500AUHours")]
    CommitmentFiveHundredAUHours,

    [Description("Commitment_500000AUHours")]
    CommitmentFiveHundredThousandAUHours,

    [Description("Commitment_5000AUHours")]
    CommitmentFiveThousandAUHours,

    [Description("Commitment_50000AUHours")]
    CommitmentFiveZeroThousandAUHours,

    [Description("Commitment_100AUHours")]
    CommitmentOneHundredAUHours,

    [Description("Commitment_100000AUHours")]
    CommitmentOneHundredThousandAUHours,

    [Description("Commitment_1000AUHours")]
    CommitmentOneThousandAUHours,

    [Description("Commitment_10000AUHours")]
    CommitmentOneZeroThousandAUHours,

    [Description("Consumption")]
    Consumption,
}
