using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateEnumConstant
{
    [Description("Created")]
    Created,

    [Description("Deleted")]
    Deleted,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unknown")]
    Unknown,

    [Description("Updating")]
    Updating,
}
