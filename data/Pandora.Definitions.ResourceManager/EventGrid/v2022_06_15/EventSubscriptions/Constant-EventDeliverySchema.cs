// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.EventSubscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventDeliverySchemaConstant
{
    [Description("CloudEventSchemaV1_0")]
    CloudEventSchemaVOneZero,

    [Description("CustomInputSchema")]
    CustomInputSchema,

    [Description("EventGridSchema")]
    EventGridSchema,
}
