using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TableSubTypeEnumConstant
{
    [Description("Any")]
    Any,

    [Description("Classic")]
    Classic,

    [Description("DataCollectionRuleBased")]
    DataCollectionRuleBased,
}
