// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PhoneTypeConstant
{
    [Description("Home")]
    @home,

    [Description("Business")]
    @business,

    [Description("Mobile")]
    @mobile,

    [Description("Other")]
    @other,

    [Description("Assistant")]
    @assistant,

    [Description("HomeFax")]
    @homeFax,

    [Description("BusinessFax")]
    @businessFax,

    [Description("OtherFax")]
    @otherFax,

    [Description("Pager")]
    @pager,

    [Description("Radio")]
    @radio,
}
