using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AdvancedFilterOperatorTypeConstant
    {
        [Description("BoolEquals")]
        BoolEquals,

        [Description("IsNotNull")]
        IsNotNull,

        [Description("IsNullOrUndefined")]
        IsNullOrUndefined,

        [Description("NumberGreaterThan")]
        NumberGreaterThan,

        [Description("NumberGreaterThanOrEquals")]
        NumberGreaterThanOrEquals,

        [Description("NumberIn")]
        NumberIn,

        [Description("NumberInRange")]
        NumberInRange,

        [Description("NumberLessThan")]
        NumberLessThan,

        [Description("NumberLessThanOrEquals")]
        NumberLessThanOrEquals,

        [Description("NumberNotIn")]
        NumberNotIn,

        [Description("NumberNotInRange")]
        NumberNotInRange,

        [Description("StringBeginsWith")]
        StringBeginsWith,

        [Description("StringContains")]
        StringContains,

        [Description("StringEndsWith")]
        StringEndsWith,

        [Description("StringIn")]
        StringIn,

        [Description("StringNotBeginsWith")]
        StringNotBeginsWith,

        [Description("StringNotContains")]
        StringNotContains,

        [Description("StringNotEndsWith")]
        StringNotEndsWith,

        [Description("StringNotIn")]
        StringNotIn,
    }
}
