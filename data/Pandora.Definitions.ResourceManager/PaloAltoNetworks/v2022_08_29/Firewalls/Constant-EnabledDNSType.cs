using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.Firewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnabledDNSTypeConstant
{
    [Description("AZURE")]
    AZURE,

    [Description("CUSTOM")]
    CUSTOM,
}
