using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.FailoverGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReadOnlyEndpointFailoverPolicyConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
