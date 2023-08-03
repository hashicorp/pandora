// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SimulationStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Draft")]
    @draft,

    [Description("Running")]
    @running,

    [Description("Scheduled")]
    @scheduled,

    [Description("Succeeded")]
    @succeeded,

    [Description("Failed")]
    @failed,

    [Description("Cancelled")]
    @cancelled,

    [Description("Excluded")]
    @excluded,
}
