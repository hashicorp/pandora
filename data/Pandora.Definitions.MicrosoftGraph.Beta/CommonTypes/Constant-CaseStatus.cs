// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CaseStatusConstant
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
