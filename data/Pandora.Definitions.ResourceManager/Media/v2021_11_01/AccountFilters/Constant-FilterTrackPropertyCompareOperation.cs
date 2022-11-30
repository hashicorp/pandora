using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.AccountFilters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FilterTrackPropertyCompareOperationConstant
{
    [Description("Equal")]
    Equal,

    [Description("NotEqual")]
    NotEqual,
}
