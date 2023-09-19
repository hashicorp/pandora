// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityContainerImageEvidenceVerdictConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Suspicious")]
    @suspicious,

    [Description("Malicious")]
    @malicious,

    [Description("NoThreatsFound")]
    @noThreatsFound,
}
