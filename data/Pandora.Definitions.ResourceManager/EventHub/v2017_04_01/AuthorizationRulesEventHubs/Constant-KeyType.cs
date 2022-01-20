using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesEventHubs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyTypeConstant
{
    [Description("PrimaryKey")]
    PrimaryKey,

    [Description("SecondaryKey")]
    SecondaryKey,
}
