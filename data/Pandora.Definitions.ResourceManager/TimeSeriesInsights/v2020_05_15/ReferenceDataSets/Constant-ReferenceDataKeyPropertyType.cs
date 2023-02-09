using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.ReferenceDataSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReferenceDataKeyPropertyTypeConstant
{
    [Description("Bool")]
    Bool,

    [Description("DateTime")]
    DateTime,

    [Description("Double")]
    Double,

    [Description("String")]
    String,
}
