using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AAD.v2022_12_01.DomainServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncKerberosPasswordsConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
