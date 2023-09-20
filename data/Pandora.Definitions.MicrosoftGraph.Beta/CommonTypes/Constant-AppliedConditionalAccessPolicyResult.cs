// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppliedConditionalAccessPolicyResultConstant
{
    [Description("Success")]
    @success,

    [Description("Failure")]
    @failure,

    [Description("NotApplied")]
    @notApplied,

    [Description("NotEnabled")]
    @notEnabled,

    [Description("Unknown")]
    @unknown,

    [Description("ReportOnlySuccess")]
    @reportOnlySuccess,

    [Description("ReportOnlyFailure")]
    @reportOnlyFailure,

    [Description("ReportOnlyNotApplied")]
    @reportOnlyNotApplied,

    [Description("ReportOnlyInterrupted")]
    @reportOnlyInterrupted,
}
