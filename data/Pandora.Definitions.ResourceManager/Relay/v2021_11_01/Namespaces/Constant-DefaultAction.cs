using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Relay.v2021_11_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DefaultActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
