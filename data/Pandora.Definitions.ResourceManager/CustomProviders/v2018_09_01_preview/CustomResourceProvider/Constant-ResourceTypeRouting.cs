using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ResourceTypeRoutingConstant
    {
        [Description("Proxy")]
        Proxy,

        [Description("Proxy,Cache")]
        ProxyCache,
    }
}
