using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.VMHost;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMHostUpdateStatesConstant
{
    [Description("Delete")]
    Delete,

    [Description("Install")]
    Install,
}
