// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityEdiscoveryCaseStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Active")]
    @active,

    [Description("PendingDelete")]
    @pendingDelete,

    [Description("Closing")]
    @closing,

    [Description("Closed")]
    @closed,

    [Description("ClosedWithError")]
    @closedWithError,
}
