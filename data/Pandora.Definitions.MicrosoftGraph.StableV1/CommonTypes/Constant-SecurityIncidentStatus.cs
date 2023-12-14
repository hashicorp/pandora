// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityIncidentStatusConstant
{
    [Description("Active")]
    @active,

    [Description("Resolved")]
    @resolved,

    [Description("InProgress")]
    @inProgress,

    [Description("Redirected")]
    @redirected,

    [Description("AwaitingAction")]
    @awaitingAction,
}
