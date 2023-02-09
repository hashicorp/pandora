using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Trigger;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Inactive")]
    Inactive,

    [Description("SourceSynchronizationSettingDeleted")]
    SourceSynchronizationSettingDeleted,
}
