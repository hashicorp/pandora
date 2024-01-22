// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.StreamingJobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventGridEventSchemaTypeConstant
{
    [Description("CloudEventSchema")]
    CloudEventSchema,

    [Description("EventGridEventSchema")]
    EventGridEventSchema,
}
