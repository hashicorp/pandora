// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EducationSubmissionStatusConstant
{
    [Description("Working")]
    @working,

    [Description("Submitted")]
    @submitted,

    [Description("Released")]
    @released,

    [Description("Returned")]
    @returned,

    [Description("Reassigned")]
    @reassigned,
}
