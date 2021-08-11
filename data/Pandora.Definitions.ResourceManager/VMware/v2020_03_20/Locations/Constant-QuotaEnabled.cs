using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Locations
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum QuotaEnabledConstant
    {
        [Description("Disabled")]
        Disabled,

        [Description("Enabled")]
        Enabled,
    }
}
