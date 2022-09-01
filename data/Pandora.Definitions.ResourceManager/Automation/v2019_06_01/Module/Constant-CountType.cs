using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.Module;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CountTypeConstant
{
    [Description("nodeconfiguration")]
    Nodeconfiguration,

    [Description("status")]
    Status,
}
