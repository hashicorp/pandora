// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("NewAlert")]
    @newAlert,

    [Description("InProgress")]
    @inProgress,

    [Description("Resolved")]
    @resolved,

    [Description("Dismissed")]
    @dismissed,
}
