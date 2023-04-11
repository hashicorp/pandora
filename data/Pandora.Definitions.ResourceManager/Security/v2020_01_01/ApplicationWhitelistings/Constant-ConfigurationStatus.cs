using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationStatusConstant
{
    [Description("Configured")]
    Configured,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("NoStatus")]
    NoStatus,

    [Description("NotConfigured")]
    NotConfigured,
}
