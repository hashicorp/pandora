using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.Trigger;

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
