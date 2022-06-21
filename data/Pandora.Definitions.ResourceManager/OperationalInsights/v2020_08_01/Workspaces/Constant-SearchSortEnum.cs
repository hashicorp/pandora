using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SearchSortEnumConstant
{
    [Description("asc")]
    Asc,

    [Description("desc")]
    Desc,
}
