// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedTenantsWorkloadActionDeploymentStatusStatusConstant
{
    [Description("ToAddress")]
    @toAddress,

    [Description("Completed")]
    @completed,

    [Description("Error")]
    @error,

    [Description("TimeOut")]
    @timeOut,

    [Description("InProgress")]
    @inProgress,
}
