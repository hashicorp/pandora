using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertProcessingRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecurrenceTypeConstant
{
    [Description("Daily")]
    Daily,

    [Description("Monthly")]
    Monthly,

    [Description("Weekly")]
    Weekly,
}
