using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TlsVersionConstant
{
    [Description("1.1")]
    OnePointOne,

    [Description("1.2")]
    OnePointTwo,

    [Description("1.0")]
    OnePointZero,
}
