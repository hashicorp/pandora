// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidForWorkEnrollmentTargetConstant
{
    [Description("None")]
    @none,

    [Description("All")]
    @all,

    [Description("Targeted")]
    @targeted,

    [Description("TargetedAsEnrollmentRestrictions")]
    @targetedAsEnrollmentRestrictions,
}
