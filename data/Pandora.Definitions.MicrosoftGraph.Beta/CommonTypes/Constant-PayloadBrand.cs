// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PayloadBrandConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Other")]
    @other,

    [Description("AmericanExpress")]
    @americanExpress,

    [Description("CapitalOne")]
    @capitalOne,

    [Description("Dhl")]
    @dhl,

    [Description("DocuSign")]
    @docuSign,

    [Description("Dropbox")]
    @dropbox,

    [Description("Facebook")]
    @facebook,

    [Description("FirstAmerican")]
    @firstAmerican,

    [Description("Microsoft")]
    @microsoft,

    [Description("Netflix")]
    @netflix,

    [Description("Scotiabank")]
    @scotiabank,

    [Description("SendGrid")]
    @sendGrid,

    [Description("StewartTitle")]
    @stewartTitle,

    [Description("Tesco")]
    @tesco,

    [Description("WellsFargo")]
    @wellsFargo,

    [Description("SyrinxCloud")]
    @syrinxCloud,

    [Description("Adobe")]
    @adobe,

    [Description("Teams")]
    @teams,

    [Description("Zoom")]
    @zoom,
}
