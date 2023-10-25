using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.InstanceFailoverGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReadWriteEndpointFailoverPolicyConstant
{
    [Description("Automatic")]
    Automatic,

    [Description("Manual")]
    Manual,
}
