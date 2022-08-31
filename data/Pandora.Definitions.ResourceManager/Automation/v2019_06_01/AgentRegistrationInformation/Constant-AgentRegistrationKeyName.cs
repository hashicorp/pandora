using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.AgentRegistrationInformation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentRegistrationKeyNameConstant
{
    [Description("primary")]
    Primary,

    [Description("secondary")]
    Secondary,
}
