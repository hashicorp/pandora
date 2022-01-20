using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TierTypeConstant
{
    [Description("Commitment_500AUHours")]
    CommitmentFiveZeroZeroAUHours,

    [Description("Commitment_5000AUHours")]
    CommitmentFiveZeroZeroZeroAUHours,

    [Description("Commitment_50000AUHours")]
    CommitmentFiveZeroZeroZeroZeroAUHours,

    [Description("Commitment_500000AUHours")]
    CommitmentFiveZeroZeroZeroZeroZeroAUHours,

    [Description("Commitment_100AUHours")]
    CommitmentOneZeroZeroAUHours,

    [Description("Commitment_1000AUHours")]
    CommitmentOneZeroZeroZeroAUHours,

    [Description("Commitment_10000AUHours")]
    CommitmentOneZeroZeroZeroZeroAUHours,

    [Description("Commitment_100000AUHours")]
    CommitmentOneZeroZeroZeroZeroZeroAUHours,

    [Description("Consumption")]
    Consumption,
}
