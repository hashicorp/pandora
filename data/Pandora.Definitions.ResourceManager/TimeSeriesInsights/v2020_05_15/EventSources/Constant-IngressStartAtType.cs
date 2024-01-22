// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.EventSources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngressStartAtTypeConstant
{
    [Description("CustomEnqueuedTime")]
    CustomEnqueuedTime,

    [Description("EarliestAvailable")]
    EarliestAvailable,

    [Description("EventSourceCreationTime")]
    EventSourceCreationTime,
}
