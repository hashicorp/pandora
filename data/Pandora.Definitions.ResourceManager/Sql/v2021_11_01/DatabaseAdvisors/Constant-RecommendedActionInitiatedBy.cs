using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DatabaseAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendedActionInitiatedByConstant
{
    [Description("System")]
    System,

    [Description("User")]
    User,
}
