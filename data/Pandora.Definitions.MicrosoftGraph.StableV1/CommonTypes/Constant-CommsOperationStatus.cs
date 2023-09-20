// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommsOperationStatusConstant
{
    [Description("NotStarted")]
    @NotStarted,

    [Description("Running")]
    @Running,

    [Description("Completed")]
    @Completed,

    [Description("Failed")]
    @Failed,
}
