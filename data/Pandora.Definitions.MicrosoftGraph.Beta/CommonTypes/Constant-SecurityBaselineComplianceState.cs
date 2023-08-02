// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityBaselineComplianceStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Secure")]
    @secure,

    [Description("NotApplicable")]
    @notApplicable,

    [Description("NotSecure")]
    @notSecure,

    [Description("Error")]
    @error,

    [Description("Conflict")]
    @conflict,
}
