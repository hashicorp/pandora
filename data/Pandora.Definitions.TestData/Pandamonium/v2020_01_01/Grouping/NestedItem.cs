using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class NestedItem
    {
        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("someDate")]
        public DateTime SomeDate { get; set; }

        [JsonPropertyName("someObject")]
        public object SomeObject { get; set; }

        [JsonPropertyName("uniqueId")]
        public string UniqueId { get; set; }

        [JsonPropertyName("floatValue")]
        public FloatBasedEnum FloatValue { get; set; }

        [JsonPropertyName("integerValue")]
        public IntegerBackedEnum IntValue { get; set; }

        [JsonPropertyName("stringValue")]
        public StringBackedEnum StringValue { get; set; }
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.Float)]
    public enum FloatBasedEnum
    {
        [Description("1.1")]
        OnePointOne,

        [Description("2.304")]
        TwoPointThreeZeroFour,
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
    public enum IntegerBackedEnum
    {
        [Description("1")]
        One,

        [Description("2")]
        Two,
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    public enum StringBackedEnum
    {
        [Description("First")]
        First,

        [Description("Second")]
        Second
    }
}