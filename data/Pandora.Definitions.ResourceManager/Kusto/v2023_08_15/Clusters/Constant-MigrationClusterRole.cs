using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationClusterRoleConstant
{
    [Description("Destination")]
    Destination,

    [Description("Source")]
    Source,
}
