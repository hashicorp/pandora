using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.BatchAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PoolAllocationModeConstant
{
    [Description("BatchService")]
    BatchService,

    [Description("UserSubscription")]
    UserSubscription,
}
