using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.SmartGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SmartGroupModificationEventConstant
{
    [Description("AlertAdded")]
    AlertAdded,

    [Description("AlertRemoved")]
    AlertRemoved,

    [Description("SmartGroupCreated")]
    SmartGroupCreated,

    [Description("StateChange")]
    StateChange,
}
