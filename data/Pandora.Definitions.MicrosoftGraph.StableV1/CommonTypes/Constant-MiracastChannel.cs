// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MiracastChannelConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("One")]
    @one,

    [Description("Two")]
    @two,

    [Description("Three")]
    @three,

    [Description("Four")]
    @four,

    [Description("Five")]
    @five,

    [Description("Six")]
    @six,

    [Description("Seven")]
    @seven,

    [Description("Eight")]
    @eight,

    [Description("Nine")]
    @nine,

    [Description("Ten")]
    @ten,

    [Description("Eleven")]
    @eleven,

    [Description("ThirtySix")]
    @thirtySix,

    [Description("Forty")]
    @forty,

    [Description("FortyFour")]
    @fortyFour,

    [Description("FortyEight")]
    @fortyEight,

    [Description("OneHundredFortyNine")]
    @oneHundredFortyNine,

    [Description("OneHundredFiftyThree")]
    @oneHundredFiftyThree,

    [Description("OneHundredFiftySeven")]
    @oneHundredFiftySeven,

    [Description("OneHundredSixtyOne")]
    @oneHundredSixtyOne,

    [Description("OneHundredSixtyFive")]
    @oneHundredSixtyFive,
}
