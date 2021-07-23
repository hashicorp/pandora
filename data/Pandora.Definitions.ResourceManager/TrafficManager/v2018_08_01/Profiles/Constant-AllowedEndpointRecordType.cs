using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AllowedEndpointRecordType
    {
        [Description("Any")]
        Any,

        [Description("DomainName")]
        DomainName,

        [Description("IPv4Address")]
        IPvFourAddress,

        [Description("IPv6Address")]
        IPvSixAddress,
    }
}
