// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VppTokenLastSyncStatusConstant
{
    [Description("None")]
    @none,

    [Description("InProgress")]
    @inProgress,

    [Description("Completed")]
    @completed,

    [Description("Failed")]
    @failed,
}
