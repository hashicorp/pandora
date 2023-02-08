using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.AgentRegistrationInformation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentRegistrationKeyNameConstant
{
    [Description("primary")]
    Primary,

    [Description("secondary")]
    Secondary,
}
