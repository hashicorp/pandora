// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ColumnTypesConstant
{
    [Description("Note")]
    @note,

    [Description("Text")]
    @text,

    [Description("Choice")]
    @choice,

    [Description("Multichoice")]
    @multichoice,

    [Description("Number")]
    @number,

    [Description("Currency")]
    @currency,

    [Description("DateTime")]
    @dateTime,

    [Description("Lookup")]
    @lookup,

    [Description("Boolean")]
    @boolean,

    [Description("User")]
    @user,

    [Description("Url")]
    @url,

    [Description("Calculated")]
    @calculated,

    [Description("Location")]
    @location,

    [Description("Geolocation")]
    @geolocation,

    [Description("Term")]
    @term,

    [Description("Multiterm")]
    @multiterm,

    [Description("Thumbnail")]
    @thumbnail,

    [Description("ApprovalStatus")]
    @approvalStatus,
}
