using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertsManagement;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorConstant
{
    [Description("Contains")]
    Contains,

    [Description("DoesNotContain")]
    DoesNotContain,

    [Description("Equals")]
    Equals,

    [Description("NotEquals")]
    NotEquals,
}
