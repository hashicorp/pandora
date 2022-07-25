using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_05_01.Media;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccountEncryptionKeyTypeConstant
{
    [Description("CustomerKey")]
    CustomerKey,

    [Description("SystemKey")]
    SystemKey,
}
