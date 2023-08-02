// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EmbeddedSIMDeviceStateValueConstant
{
    [Description("NotEvaluated")]
    @notEvaluated,

    [Description("Failed")]
    @failed,

    [Description("Installing")]
    @installing,

    [Description("Installed")]
    @installed,

    [Description("Deleting")]
    @deleting,

    [Description("Error")]
    @error,

    [Description("Deleted")]
    @deleted,

    [Description("RemovedByUser")]
    @removedByUser,
}
