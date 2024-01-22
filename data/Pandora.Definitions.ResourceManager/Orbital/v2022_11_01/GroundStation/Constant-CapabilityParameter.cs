// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_11_01.GroundStation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CapabilityParameterConstant
{
    [Description("Communication")]
    Communication,

    [Description("EarthObservation")]
    EarthObservation,
}
