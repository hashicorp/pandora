using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TagOperatorsConstant
{
    [Description("All")]
    All,

    [Description("Any")]
    Any,
}
