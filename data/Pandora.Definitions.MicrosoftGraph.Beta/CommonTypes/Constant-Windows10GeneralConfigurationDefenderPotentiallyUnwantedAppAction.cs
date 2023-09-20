// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10GeneralConfigurationDefenderPotentiallyUnwantedAppActionConstant
{
    [Description("DeviceDefault")]
    @deviceDefault,

    [Description("Block")]
    @block,

    [Description("Audit")]
    @audit,
}
