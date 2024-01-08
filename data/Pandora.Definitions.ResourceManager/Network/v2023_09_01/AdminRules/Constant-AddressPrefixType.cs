using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.AdminRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AddressPrefixTypeConstant
{
    [Description("IPPrefix")]
    IPPrefix,

    [Description("ServiceTag")]
    ServiceTag,
}
