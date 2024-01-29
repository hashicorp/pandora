// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01.KafkaConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventStreamingTypeConstant
{
    [Description("Azure")]
    Azure,

    [Description("Managed")]
    Managed,

    [Description("None")]
    None,
}
