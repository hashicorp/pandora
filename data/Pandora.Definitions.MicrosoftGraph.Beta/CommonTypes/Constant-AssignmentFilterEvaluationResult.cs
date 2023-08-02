// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentFilterEvaluationResultConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Match")]
    @match,

    [Description("NotMatch")]
    @notMatch,

    [Description("Inconclusive")]
    @inconclusive,

    [Description("Failure")]
    @failure,

    [Description("NotEvaluated")]
    @notEvaluated,
}
