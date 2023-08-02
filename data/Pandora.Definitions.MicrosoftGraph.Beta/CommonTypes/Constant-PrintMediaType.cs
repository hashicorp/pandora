// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrintMediaTypeConstant
{
    [Description("Stationery")]
    @stationery,

    [Description("Transparency")]
    @transparency,

    [Description("Envelope")]
    @envelope,

    [Description("EnvelopePlain")]
    @envelopePlain,

    [Description("Continuous")]
    @continuous,

    [Description("Screen")]
    @screen,

    [Description("ScreenPaged")]
    @screenPaged,

    [Description("ContinuousLong")]
    @continuousLong,

    [Description("ContinuousShort")]
    @continuousShort,

    [Description("EnvelopeWindow")]
    @envelopeWindow,

    [Description("MultiPartForm")]
    @multiPartForm,

    [Description("MultiLayer")]
    @multiLayer,

    [Description("Labels")]
    @labels,
}
