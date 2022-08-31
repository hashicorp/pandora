using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview.TopicsAuthorizationRule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyTypeConstant
{
    [Description("PrimaryKey")]
    PrimaryKey,

    [Description("SecondaryKey")]
    SecondaryKey,
}
