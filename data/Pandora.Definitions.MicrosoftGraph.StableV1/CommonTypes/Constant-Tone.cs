// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ToneConstant
{
    [Description("Tone0")]
    @tone0,

    [Description("Tone1")]
    @tone1,

    [Description("Tone2")]
    @tone2,

    [Description("Tone3")]
    @tone3,

    [Description("Tone4")]
    @tone4,

    [Description("Tone5")]
    @tone5,

    [Description("Tone6")]
    @tone6,

    [Description("Tone7")]
    @tone7,

    [Description("Tone8")]
    @tone8,

    [Description("Tone9")]
    @tone9,

    [Description("Star")]
    @star,

    [Description("Pound")]
    @pound,

    [Description("A")]
    @a,

    [Description("B")]
    @b,

    [Description("C")]
    @c,

    [Description("D")]
    @d,

    [Description("Flash")]
    @flash,
}
