// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsUpdateForBusinessUpdateWeeksConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("FirstWeek")]
    @firstWeek,

    [Description("SecondWeek")]
    @secondWeek,

    [Description("ThirdWeek")]
    @thirdWeek,

    [Description("FourthWeek")]
    @fourthWeek,

    [Description("EveryWeek")]
    @everyWeek,
}
