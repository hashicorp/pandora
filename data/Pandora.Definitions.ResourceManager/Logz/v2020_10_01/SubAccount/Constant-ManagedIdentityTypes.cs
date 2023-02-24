using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.SubAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedIdentityTypesConstant
{
    [Description("SystemAssigned")]
    SystemAssigned,

    [Description("UserAssigned")]
    UserAssigned,
}
