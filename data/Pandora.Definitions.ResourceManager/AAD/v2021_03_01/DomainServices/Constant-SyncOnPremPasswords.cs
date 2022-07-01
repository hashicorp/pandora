using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AAD.v2021_03_01.DomainServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncOnPremPasswordsConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
