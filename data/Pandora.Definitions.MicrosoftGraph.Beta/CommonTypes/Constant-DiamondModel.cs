// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiamondModelConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Adversary")]
    @adversary,

    [Description("Capability")]
    @capability,

    [Description("Infrastructure")]
    @infrastructure,

    [Description("Victim")]
    @victim,
}
