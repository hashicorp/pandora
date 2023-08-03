// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsDeviceHealthStateConstant
{
    [Description("Clean")]
    @clean,

    [Description("FullScanPending")]
    @fullScanPending,

    [Description("RebootPending")]
    @rebootPending,

    [Description("ManualStepsPending")]
    @manualStepsPending,

    [Description("OfflineScanPending")]
    @offlineScanPending,

    [Description("Critical")]
    @critical,
}
