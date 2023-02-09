using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.ShareSubscription;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SynchronizationModeConstant
{
    [Description("FullSync")]
    FullSync,

    [Description("Incremental")]
    Incremental,
}
