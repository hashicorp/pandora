using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ServerAdvisors;

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
