using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.Contact;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContactsStatusConstant
{
    [Description("cancelled")]
    Cancelled,

    [Description("failed")]
    Failed,

    [Description("providerCancelled")]
    ProviderCancelled,

    [Description("scheduled")]
    Scheduled,

    [Description("succeeded")]
    Succeeded,
}
