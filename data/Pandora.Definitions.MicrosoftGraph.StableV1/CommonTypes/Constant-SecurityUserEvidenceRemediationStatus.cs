// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityUserEvidenceRemediationStatusConstant
{
    [Description("None")]
    @none,

    [Description("Remediated")]
    @remediated,

    [Description("Prevented")]
    @prevented,

    [Description("Blocked")]
    @blocked,

    [Description("NotFound")]
    @notFound,
}
