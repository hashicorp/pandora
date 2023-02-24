using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggerruns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunQueryFilterOperatorConstant
{
    [Description("Equals")]
    Equals,

    [Description("In")]
    In,

    [Description("NotEquals")]
    NotEquals,

    [Description("NotIn")]
    NotIn,
}
