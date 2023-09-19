// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceManagementStateConstant
{
    [Description("Managed")]
    @managed,

    [Description("RetirePending")]
    @retirePending,

    [Description("RetireFailed")]
    @retireFailed,

    [Description("WipePending")]
    @wipePending,

    [Description("WipeFailed")]
    @wipeFailed,

    [Description("Unhealthy")]
    @unhealthy,

    [Description("DeletePending")]
    @deletePending,

    [Description("RetireIssued")]
    @retireIssued,

    [Description("WipeIssued")]
    @wipeIssued,

    [Description("WipeCanceled")]
    @wipeCanceled,

    [Description("RetireCanceled")]
    @retireCanceled,

    [Description("Discovered")]
    @discovered,
}
