// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosUpdateDeviceStatusStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("NotApplicable")]
    @notApplicable,

    [Description("Compliant")]
    @compliant,

    [Description("Remediated")]
    @remediated,

    [Description("NonCompliant")]
    @nonCompliant,

    [Description("Error")]
    @error,

    [Description("Conflict")]
    @conflict,

    [Description("NotAssigned")]
    @notAssigned,
}
