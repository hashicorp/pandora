using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.FailoverGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReadWriteEndpointFailoverPolicyConstant
{
    [Description("Automatic")]
    Automatic,

    [Description("Manual")]
    Manual,
}
