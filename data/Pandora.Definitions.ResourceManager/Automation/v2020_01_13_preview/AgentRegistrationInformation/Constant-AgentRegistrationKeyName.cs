using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.AgentRegistrationInformation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentRegistrationKeyNameConstant
{
    [Description("primary")]
    Primary,

    [Description("secondary")]
    Secondary,
}
