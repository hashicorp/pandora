// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RetentionLabelSettingsBehaviorDuringRetentionPeriodConstant
{
    [Description("DoNotRetain")]
    @doNotRetain,

    [Description("Retain")]
    @retain,

    [Description("RetainAsRecord")]
    @retainAsRecord,

    [Description("RetainAsRegulatoryRecord")]
    @retainAsRegulatoryRecord,
}
