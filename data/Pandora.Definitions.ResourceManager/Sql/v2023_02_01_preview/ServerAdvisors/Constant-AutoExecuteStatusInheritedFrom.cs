using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ServerAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutoExecuteStatusInheritedFromConstant
{
    [Description("Database")]
    Database,

    [Description("Default")]
    Default,

    [Description("ElasticPool")]
    ElasticPool,

    [Description("Server")]
    Server,

    [Description("Subscription")]
    Subscription,
}
