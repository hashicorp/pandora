using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Accounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageAccountTypeConstant
{
    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,
}
