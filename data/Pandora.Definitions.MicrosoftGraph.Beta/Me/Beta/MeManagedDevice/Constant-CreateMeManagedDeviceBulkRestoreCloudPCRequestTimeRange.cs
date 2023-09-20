// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDevice;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateMeManagedDeviceBulkRestoreCloudPCRequestTimeRangeConstant
{
    [Description("Before")]
    @before,

    [Description("After")]
    @after,

    [Description("BeforeOrAfter")]
    @beforeOrAfter,
}
