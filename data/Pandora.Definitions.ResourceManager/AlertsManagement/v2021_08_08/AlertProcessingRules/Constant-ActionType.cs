using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertProcessingRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionTypeConstant
{
    [Description("AddActionGroups")]
    AddActionGroups,

    [Description("RemoveAllActionGroups")]
    RemoveAllActionGroups,
}
