using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PublicNetworkAccessConstant
    {
        [Description("Disabled")]
        Disabled,

        [Description("Enabled")]
        Enabled,
    }
}
