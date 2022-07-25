using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.AuthorizationRulesEventHubs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyTypeConstant
{
    [Description("PrimaryKey")]
    PrimaryKey,

    [Description("SecondaryKey")]
    SecondaryKey,
}
